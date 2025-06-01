using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameView : MonoBehaviour
{
    [Header("BackGround")]
    public GameObject[] quizBackGroundGameObjects;

    [Header("Score")]
    public Image scoreImage;
    public Sprite[] scoreSprites;

    [Header("Lines")]
    public GameObject oneLineParent;
    public GameObject oneLine;
    public GameObject[] oneLineArrows;

    public GameObject twoLineParent;

    public GameObject twoLineUp;
    public GameObject[] twoLineUpArrows;

    public GameObject twoLineDown;
    public GameObject[] twoLineDownArrows;

    public Sprite leftToRightArrow;
    public Sprite rightToLeftArrow;

    [Header("ObjectPool")]
    public ObjectPool objectPool;

    [Header("Audio")]
    public AudioManager audioManager;

    [Header("InGame")]
    public InGameManager inGameManager;

    public InGameTimeLine inGameTimeLine;

    private void Start()
    {
        // oneLineParent.SetActive(false);
        // twoLineParent.SetActive(false);
    }

    public void ChangeStage()
    {
        inGameTimeLine.PlayStop();
        audioManager.PlayAudio(EnumAudio.StartStop);
        Invoke(nameof(PalyStageChangeAudio), 2.0f);
        Invoke(nameof(PalyStageChangeAudio), 3.7f);
    }

    private void PalyStageChangeAudio()
    {
        audioManager.PlayAudio(EnumAudio.StageChange);
    }

    public void CloseHouse()
    {
        foreach (Transform item in oneLine.transform)
        {
            if (item.GetComponent<NewHouseItem>() != null)
                item.GetComponent<NewHouseItem>().CloseHouse();
        }

        foreach (Transform item in twoLineUp.transform)
        {
            if (item.GetComponent<NewHouseItem>() != null)
                item.GetComponent<NewHouseItem>().CloseHouse();
        }

        foreach (Transform item in twoLineDown.transform)
        {
            if (item.GetComponent<NewHouseItem>() != null)
                item.GetComponent<NewHouseItem>().CloseHouse();
        }
    }

    public void OpenHouse(List<AnswerLine> answerLines)
    {
        if (answerLines.Count == 1)
        {
            foreach (var item in answerLines)
            {
                for (int i = 0; i < item.newHousePositions.Count; i++)
                {
                    int position = item.newHousePositions[i];
                    oneLine.transform.GetChild(position).GetComponent<NewHouseItem>().OpenHouse();
                    oneLine.transform.GetChild(position).GetComponent<NewHouseItem>().SetHouse(item.newHouseTypes[i]);
                }
            }
        }

        if (answerLines.Count == 2)
        {
            for (int i = 0; i < answerLines.Count; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < answerLines[i].newHousePositions.Count; j++)
                    {
                        int position = answerLines[i].newHousePositions[j];
                        twoLineUp.transform.GetChild(position).GetComponent<NewHouseItem>().OpenHouse();
                        twoLineUp.transform.GetChild(position).GetComponent<NewHouseItem>().SetHouse(answerLines[i].newHouseTypes[j]);
                    }
                }

                if (i == 1)
                {
                    for (int j = 0; j < answerLines[i].newHousePositions.Count; j++)
                    {
                        int position = answerLines[i].newHousePositions[j];
                        twoLineDown.transform.GetChild(position).GetComponent<NewHouseItem>().OpenHouse();
                        twoLineDown.transform.GetChild(position).GetComponent<NewHouseItem>().SetHouse(answerLines[i].newHouseTypes[j]);
                    }
                }
            }
        }
    }

    public void CloseAllQuizBackGroundGameObjects()
    {
        foreach (var obj in quizBackGroundGameObjects)
        {
            if (obj.name != "base")
                obj.SetActive(false);
        }
    }

    public void OpenQuizBackGroundGameObject(int _index)
    {
        quizBackGroundGameObjects[_index].SetActive(true);
    }

    public void OpenLine(int lineCount)
    {
        if (lineCount == 1)
        {
            oneLineParent.SetActive(true);
            twoLineParent.SetActive(false);
        }

        if (lineCount == 2)
        {
            oneLineParent.SetActive(false);
            twoLineParent.SetActive(true);
        }
    }

    public void SetLineArrow(List<AnswerLine> answerLines)
    {
        int lineNumber = answerLines.Count;
        if(lineNumber == 1)
        {
            SetOnLineArrow(1, answerLines[0].lineDirection);
        }
        if(lineNumber == 2)
        {
            SetOnLineArrow(2, answerLines[0].lineDirection);
            SetOnLineArrow(3, answerLines[1].lineDirection);
        }
    }

    private void SetOnLineArrow(int lineNumber, LineDirection lineArrow)
    {
        GameObject[] targetLineArrows = GetTargetLineArrows(lineNumber);
        Sprite arrowSprite = GetArrowSprite(lineArrow);

        if (targetLineArrows != null && arrowSprite != null)
        {
            foreach (var obj in targetLineArrows)
            {
                obj.GetComponent<SpriteRenderer>().sprite = arrowSprite;
            }
        }
    }

    private GameObject[] GetTargetLineArrows(int lineNumber)
    {
        return lineNumber switch
        {
            1 => oneLineArrows,
            2 => twoLineUpArrows,
            3 => twoLineDownArrows,
            _ => null,
        };
    }

    private Sprite GetArrowSprite(LineDirection lineArrow)
    {
        return lineArrow switch
        {
            LineDirection.LeftToRight => leftToRightArrow,
            LineDirection.RightToLeft => rightToLeftArrow,
            _ => null,
        };
    }

    public void PlayAudioBGM()
    {
        audioManager.PlayAudio(EnumAudio.InGameBGM);
    }

    public void SetScore(int _index)
    {
        scoreImage.sprite = scoreSprites[_index];
    }

    public void StartMoveMonster(int _numberLine, AnswerLine _answerLine, int _index)
    {
        objectPool.GetGameObject().GetComponent<NewMonsterView>().SetPosition(_numberLine, _answerLine);
        objectPool.GetGameObject().GetComponent<NewMonsterView>().SetSprite(_answerLine.newMonsterItems[_index].newMonsterType);
        objectPool.GetGameObject().GetComponent<NewMonsterView>().TestIndex(_index);
        objectPool.GetGameObject().GetComponent<NewMonsterView>().StartMove();
        objectPool.GetGameObject().GetComponent<NewMonsterView>().SetObjectPool(objectPool);
        objectPool.SetLineGameObject(_numberLine);
    }

    public void OnClickEvent(GameObject _gameObject, NewMonsterType _newMonsterType, NewHouseType _newHouseType, GameObject _houseObject)
    {
        if (_newHouseType == NewHouseType.NULL)
            return;

        if (_newMonsterType == NewMonsterType.BLANK)
            return;

        if (_houseObject == null)
            return;

        // * 정답
        if (inGameManager.IsCheckAnswerWrong(_newMonsterType, _newHouseType))
        {
            audioManager.PlayAudio(EnumAudio.O);
            inGameTimeLine.PlayO(_houseObject.transform.position);
            inGameManager.SetScoreAddition();
            _gameObject.SetActive(false);
            _gameObject.GetComponent<NewMonsterView>().StopMove();
            _gameObject.transform.parent = objectPool.transform;
        }
        // * 오답
        else
        {
            audioManager.PlayAudio(EnumAudio.X);
            inGameTimeLine.PlayX(_houseObject.transform.position);
            inGameManager.SetScoreSubtraction();
            _gameObject.GetComponent<NewMonsterView>().EnableBoxCollider();
        }
    }
    
    public void OnClickPopupOk()
    {
        JaeHwanUtils.Instance.sceneLoaderManager.LoadScene(SceneName.GameStart);
    }

    public void PlayStartTimeLine()
    {
        inGameTimeLine.PlayStart();
        audioManager.PlayAudio(EnumAudio.StartStop);
    }
}