using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public InGameView inGameView;
    private List<AnswerClass> answerList;

    private int index;

    private float timer = 0.0f;
    private bool isStartMoveMonster = false;
    private int monsterMoveCount = 0;
    private const int totalMonsterMoveCount = 27;

    private const float roundTime = 66; // 2.06초 기준
    // private const float roundTime = 60; // 1.86초 기준

    private int score;

    private void Start()
    {
        Time.timeScale = 1;
        JaeHwanUtils.Instance.sceneLoaderManager.LoadingCompleteAction(Play);
        JaeHwanUtils.Instance.sceneLoaderManager.SetAddressableLoadingState(AddressableLoadingState.END);
    }

    private void Play()
    {
        JaeHwanUtils.Instance.sceneLoaderManager.CloseSceneLoading();
        score = 0;
        index = 0;
        Answers answers = new();
        answerList = answers.GetSetAnswer();

        inGameView.CloseAllQuizBackGroundGameObjects();
        inGameView.OpenQuizBackGroundGameObject(index);
        inGameView.SetScore(index);
        SetLines();

        StartCoroutine(WaitCoroutine(()=> 
        { 
            StartCoroutine(StartQuiz());
        } , 0.5f));
    }

    private IEnumerator StartQuiz()
    {
        yield return new WaitForSeconds(2.5f);
        inGameView.PlayStartTimeLine();

        yield return new WaitForSeconds(1.5f);
        inGameView.PlayAudioBGM();

        yield return new WaitForSeconds(2.0f);
        monsterMoveCount = 0;
        isStartMoveMonster = true;

        yield return new WaitForSeconds(roundTime);
        ChangeStage();

        yield return new WaitForSeconds(0.5f);
        Init();

        yield return new WaitForSeconds(0.5f);
        AddIndex();

        yield return new WaitForSeconds(1.5f);
        CloseBackGrounds();

        yield return new WaitForSeconds(0.5f);
        SetLines();

        // yield return new WaitForSeconds(2.5f);
        StartCoroutine(StartQuiz());
    }

    private void SetLines()
    {
        inGameView.SetScore(index);

        inGameView.OpenLine(answerList[index].answerLines.Count);
        inGameView.SetLineArrow(answerList[index].answerLines);
        inGameView.OpenHouse(answerList[index].answerLines);
        inGameView.OpenQuizBackGroundGameObject(index);
    }

    private bool IsEndGame(int _index)
    {
        if (answerList.Count <= _index)
            return true;

        return false;
    }

    private void ChangeStage()
    {
        inGameView.ChangeStage();
    }

    private void CloseBackGrounds()
    {
        inGameView.CloseHouse();
        inGameView.CloseAllQuizBackGroundGameObjects();
    }

    private void Init()
    {
        monsterMoveCount = 0;
    }

    private void AddIndex()
    {
        index++;

        if (IsEndGame(index))
        {
            index = 0;
            StartCoroutine(WaitCoroutine(()=> 
            {
                JaeHwanUtils.Instance.sceneLoaderManager.LoadScene(SceneName.GameScore);
                Debug.LogWarning("게임 끝 !");
            } , 2.8f));
            return;
        }
    }

    IEnumerator WaitCoroutine(Action _action, float _time)
    {
        yield return new WaitForSeconds(_time);
        _action.Invoke();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (!isStartMoveMonster)
            return;

        if (timer >= 1.86f)
        // if (timer >= 2.06f)
        {
            StartMoveMonster();
            timer = 0f;

            if (totalMonsterMoveCount == monsterMoveCount)
                isStartMoveMonster = false;
        }
    }

    private void StartMoveMonster()
    {
        if (answerList[index].answerLines.Count == 1)
        {
            inGameView.StartMoveMonster(1, answerList[index].answerLines[0], monsterMoveCount);
        }

        if (answerList[index].answerLines.Count == 2)
        {
            inGameView.StartMoveMonster(2, answerList[index].answerLines[0], monsterMoveCount);
            inGameView.StartMoveMonster(3, answerList[index].answerLines[1], monsterMoveCount);
        }
        monsterMoveCount++;
    }

    public void OnClickMonster(int _lineNumber, NewMonsterType _newMonsterType, NewHouseType newHouseType)
    {

    }

    public bool IsCheckAnswerWrong(NewMonsterType _newMonsterType, NewHouseType _newHouseType)
    {
        string monsterTypeString = _newMonsterType.ToString();
        return _newHouseType.ToString().EndsWith(monsterTypeString);
    }

    public void SetScoreAddition()
    {
        score++;
        JaeHwanUtils.Instance.score = score;
    }

    public void SetScoreSubtraction()
    {
        score--;
        JaeHwanUtils.Instance.score = score;
    }
}