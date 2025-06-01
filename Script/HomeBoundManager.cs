using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class HomeBoundManager : MonoBehaviour
{
    public GameObject monsterObject;
    public ObjectPool objectPool;
    public GameObject monsterLine;
    public QuizLevelItem[] quizLevelItems;

    public int quizNum = 10;

    private int mainQuizIndex = 7;

    // !! TestCode
    public TMP_Text testScoreText;
    private int correctAnswer = 0;
    private int wrongAnswer = 0;
    private int passAnswer = 0;

    void Start()
    {
        StartCoroutine(StartTest());
    }

    // !! TestCode
    IEnumerator StartTest()
    {
        yield return new WaitForSeconds(2);

        ActivateQuizItem(mainQuizIndex);

        List<MonsterType> boxMonsterTypes = InitializeBoxMonsters(mainQuizIndex);
        int additionalMonsterLevel = GetAdditionalMonsterLevel(mainQuizIndex);

        List<MonsterType> randomMonsters = GenerateRandomMonsters(boxMonsterTypes, additionalMonsterLevel);

        AddMonstersToBox(boxMonsterTypes, randomMonsters);

        yield return RunQuizLoop(mainQuizIndex, boxMonsterTypes);

        yield return new WaitForSeconds(10);

        DeactivateQuizItem(mainQuizIndex);

        mainQuizIndex++;

        if (HasNextQuiz(mainQuizIndex))
            StartCoroutine(StartTest());
        else
            EndGame();
    }

    void ActivateQuizItem(int quizIndex)
    {
        quizLevelItems[quizIndex].gameObject.SetActive(true);
    }

    List<MonsterType> InitializeBoxMonsters(int quizIndex)
    {
        BoxItem[] boxItems = quizLevelItems[quizIndex].GetBoxItems();
        List<MonsterType> boxMonsterTypes = new List<MonsterType>();

        foreach (BoxItem boxItem in boxItems)
        {
            boxItem.SetMonsterType();
            boxMonsterTypes.Add(boxItem.GetMonsterType());
        }

        return boxMonsterTypes;
    }

    int GetAdditionalMonsterLevel(int quizIndex)
    {
        return quizLevelItems[quizIndex].GetAddMonsterLevel();
    }

    List<MonsterType> GenerateRandomMonsters(List<MonsterType> boxMonsterTypes, int additionalMonsterLevel)
    {
        List<MonsterType> availableMonsters = Enum.GetValues(typeof(MonsterType))
                                                  .Cast<MonsterType>()
                                                  .Where(monster => !boxMonsterTypes.Contains(monster))
                                                  .ToList();

        return GetRandomMonsters(availableMonsters, additionalMonsterLevel);
    }

    void AddMonstersToBox(List<MonsterType> boxMonsterTypes, List<MonsterType> randomMonsters)
    {
        foreach (var monster in randomMonsters)
        {
            boxMonsterTypes.Add(monster);
            Debug.Log(boxMonsterTypes);
        }
    }

    IEnumerator RunQuizLoop(int quizIndex, List<MonsterType> boxMonsterTypes)
    {
        for (int i = 0; i < quizNum; i++)
        {
            StartMoveQuiz(quizIndex, boxMonsterTypes);
            yield return new WaitForSeconds(2);
        }
    }

    void DeactivateQuizItem(int quizIndex)
    {
        quizLevelItems[quizIndex].gameObject.SetActive(false);
    }

    bool HasNextQuiz(int quizIndex)
    {
        return quizIndex < quizLevelItems.Length;
    }


    public void StartMoveQuiz(int _mainQuizIndex, List<MonsterType> _boxMonsterTypes)
    {
        GameObject monstergameObject = objectPool.GetGameObject();
        monstergameObject.transform.parent = monsterLine.transform;
        LineRenderer[] lineRenderers;

        int randLine;
        lineRenderers = quizLevelItems[_mainQuizIndex].GetLineRenderers();
        randLine = Random.Range(0, lineRenderers.Length);

        monstergameObject.GetComponent<MonsterItem>().SetMonsterType(GetRandomMonsterType(_boxMonsterTypes));
        monstergameObject.GetComponent<MonsterItem>().SetSprite();
        monstergameObject.GetComponent<MonsterItem>().SetLineIndex(randLine);

        monstergameObject.GetComponent<PathFollower>().StartMove(lineRenderers[randLine], objectPool.gameObject);
        monstergameObject.SetActive(true);
    }

    private MonsterType GetRandomMonsterType(List<MonsterType> _boxMonsterTypes)
    {
        int randomIndex = Random.Range(0, _boxMonsterTypes.Count);
        return _boxMonsterTypes[randomIndex];
    }

    public List<MonsterType> GetRandomMonsters(List<MonsterType> availableMonsters, int n)
    {
        System.Random random = new System.Random();
        List<MonsterType> shuffledMonsters = availableMonsters.OrderBy(x => random.Next()).ToList();

        return shuffledMonsters.Take(n).ToList();
    }

    public void CheckAnswer(QuizType _quizType, MonsterType _monsterType, MonsterType _boxType, MonsterColor _monsterColor, MonsterColor _boxColor, MonsterForm _monsterForm, MonsterForm _boxForm)
    {
        switch (_quizType)
        {
            case QuizType.OnlyColor:
                if (_monsterColor.ToString().Contains(_boxColor.ToString()))
                {
                    correctAnswer++;
                    Debug.Log("같은색");
                }
                else
                {
                    wrongAnswer++;
                }
                break;

            case QuizType.OnlyForm:
                if (_monsterForm.ToString().Contains(_boxForm.ToString()))
                {
                    correctAnswer++;
                    Debug.Log("같은 형태");
                }
                else
                {
                    wrongAnswer++;
                }
                break;

            case QuizType.Both:
                if (_boxType == _monsterType)
                {
                    correctAnswer++;
                    Debug.Log("둘다 같음");
                }
                else
                {
                    wrongAnswer++;
                }
                break;

            default:
                break;
        }

        SetScore(correctAnswer, wrongAnswer, passAnswer);
    }

    public void AddPassAnswer()
    {
        passAnswer++;
        SetScore(correctAnswer, wrongAnswer, passAnswer);
    }

    private void SetScore(int _correctAnswer, int _wrongAnswer, int _passAnswer)
    {
        testScoreText.text = "정답 : " + _correctAnswer + "  오답 : " + _wrongAnswer + "  지나감 : " + _passAnswer;
    }

    private void EndGame()
    {
        JaeHwanUtils.Instance.sceneLoaderManager.LoadScene(SceneName.GameScore);
    }
}
