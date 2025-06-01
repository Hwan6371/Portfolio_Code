using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.U2D;
using System;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using NUnit.Framework.Internal;

public class GameScoreView : MonoBehaviour
{
    [SerializeField] PlayableDirector resultPlayableDirector;

    private ScoreGrade scoreGrade;

    public GameObject[] gradeMonsterGameObjects;

    public TMP_Text scoreGrade_Text;
    public TMP_Text nextScore_Text;
    public TMP_Text nextScoreName_Text;
    public TMP_Text nextScoreContent_Text;

    public AudioSource resultAudioSource;

    private int rank = 0;

    void Start()
    {
        // ! 테스트를 위한 주석처리 시작 
        // FeelGoodUtils.Instance.score = 45;
        // ! 테스트를 위한 주석처리 끝

        JaeHwanUtils.Instance.sceneLoaderManager.PlayBgm(SceneName.GameScore);

        rank = GetRank(JaeHwanUtils.Instance.score);
        scoreGrade = GetScoreGrade(rank);
        SetScoreGradeView();
        SetScoreText();
        SetUpgradeQuizCount(GetUpgradeQuizCount(JaeHwanUtils.Instance.score));

        // ! 테스트를 위한 주석처리 시작 
        // Debug.Log("Test 시작");

        // for(int i = 0; i < 180; i++) 
        // {
        //     int testRank = GetRank(i);
        //     ScoreGrade testScoreGrade = GetScoreGrade(testRank);

        //     Debug.Log( "Test " + testScoreGrade.ToString() + " / score " + i + " / Upgrade " + GetUpgradeQuizCount(i));
        // }
        // ! 테스트를 위한 주석처리 끝

        if (IsPerfect())
            SetContent();

        StartCoroutine(WaitCoroutine(() =>
        {
            resultPlayableDirector.Play();
        }, 2.5f));

        resultAudioSource.Play();

        MiniGameScoresSaveRequestModel miniGameScoresSaveRequestModel = new()
        {
            score = JaeHwanUtils.Instance.score,
            miniGameType = JaeHwanUtils.GameName
        };

        JaeHwanUtils.Instance.serverRestApi.SendRequest_POST(ApiAddressType.POST_GAME_DATA_SAVE, miniGameScoresSaveRequestModel, (json, errorMessage) =>
        {
            Debug.Log("json : " + json);
            Debug.Log("errorMessage : " + errorMessage);
        });

        JaeHwanUtils.Instance.sceneLoaderManager.LoadingCompleteAction(() =>
        {
            JaeHwanUtils.Instance.sceneLoaderManager.CloseSceneLoading();
        });

        JaeHwanUtils.Instance.sceneLoaderManager.SetAddressableLoadingState(AddressableLoadingState.END);
    }

    IEnumerator WaitCoroutine(Action _action, float _time)
    {
        yield return new WaitForSeconds(_time);
        _action.Invoke();
    }

    public void ButtonHome()
    {
        JaeHwanUtils.Instance.sceneLoaderManager.LoadScene(SceneName.GameStart);
    }

    private int GetRank(int _score)
    {
        if (145 <= _score)
            return 10;
        else if (135 <= _score)
            return 9;
        else if (125 <= _score)
            return 8;
        else if (115 <= _score)
            return 7;
        else if (105 <= _score)
            return 6;
        else if (90 <= _score)
            return 5;
        else if (75 <= _score)
            return 4;
        else if (60 <= _score)
            return 3;
        else if (45 <= _score)
            return 2;
        else if (0 <= _score)
            return 1;
        else
            return 0;
    }

    private void SetContent()
    {
        nextScore_Text.gameObject.SetActive(false);
        nextScoreName_Text.gameObject.SetActive(false);
        nextScoreContent_Text.text = "<b>축하합니다 최고 목표를 달성했어요!</b>\n꾸준히 홈바운드 애니멀즈를 플레이해 보세요.";
        nextScoreContent_Text.alignment = TextAlignmentOptions.Center;
        nextScoreContent_Text.gameObject.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
    }

    private int GetUpgradeQuizCount(int _score)
    {
        int currentRank = GetRank(_score);
        int nextRankScore;

        if (currentRank == 1)
            nextRankScore = 45;
        else if (currentRank == 2)
            nextRankScore = 60;
        else if (currentRank == 3)
            nextRankScore = 75;
        else if (currentRank == 4)
            nextRankScore = 90;
        else if (currentRank == 5)
            nextRankScore = 105;
        else if (currentRank == 6)
            nextRankScore = 115;
        else if (currentRank == 7)
            nextRankScore = 125;
        else if (currentRank == 8)
            nextRankScore = 135;
        else if (currentRank == 9)
            nextRankScore = 145;
        else
            return 0;

        if (nextRankScore - _score == 0)
            return 1;

        return nextRankScore - _score;
    }

    private ScoreGrade GetScoreGrade(int _rank)
    {
        return _rank switch
        {
            1 => ScoreGrade.D,
            2 => ScoreGrade.C_MINUS,
            3 => ScoreGrade.C,
            4 => ScoreGrade.C_PLUS,
            5 => ScoreGrade.B_MINUS,
            6 => ScoreGrade.B,
            7 => ScoreGrade.B_PLUS,
            8 => ScoreGrade.A_MINUS,
            9 => ScoreGrade.A,
            10 => ScoreGrade.A_PLUS,
            _ => ScoreGrade.B,
        };
    }

    private void SetScoreGradeView()
    {
        switch (scoreGrade)
        {
            case ScoreGrade.A_PLUS:
            case ScoreGrade.A:
            case ScoreGrade.A_MINUS:
                break;

            case ScoreGrade.B_PLUS:
            case ScoreGrade.B:
            case ScoreGrade.B_MINUS:
                gradeMonsterGameObjects[0].SetActive(false);
                break;

            case ScoreGrade.C_PLUS:
            case ScoreGrade.C:
            case ScoreGrade.C_MINUS:
                gradeMonsterGameObjects[0].SetActive(false);
                gradeMonsterGameObjects[1].SetActive(false);
                break;

            case ScoreGrade.D:
                gradeMonsterGameObjects[0].SetActive(false);
                gradeMonsterGameObjects[1].SetActive(false);
                gradeMonsterGameObjects[2].SetActive(false);
                break;

            default:
                gradeMonsterGameObjects[0].SetActive(false);
                gradeMonsterGameObjects[1].SetActive(false);
                gradeMonsterGameObjects[2].SetActive(false);
                break;
        }
    }

    private void SetScoreText()
    {
        scoreGrade_Text.text = scoreGrade switch
        {
            ScoreGrade.A_PLUS => "A+",
            ScoreGrade.A => "A",
            ScoreGrade.A_MINUS => "A-",
            ScoreGrade.B_PLUS => "B+",
            ScoreGrade.B => "B",
            ScoreGrade.B_MINUS => "B-",
            ScoreGrade.C_PLUS => "C+",
            ScoreGrade.C => "C",
            ScoreGrade.C_MINUS => "C-",
            ScoreGrade.D => "D",
            _ => "B",
        };
    }

    private void SetUpgradeQuizCount(int _nextScore)
    {
        nextScore_Text.text = _nextScore.ToString();
    }

    private bool IsPerfect()
    {
        if (scoreGrade == ScoreGrade.A_PLUS)
            return true;

        return false;
    }

    public void OnClickReStart()
    {
        JaeHwanUtils.Instance.sceneLoaderManager.LoadScene(SceneName.GameStart);
    }
}

public class ScoreGradeValue
{
    public int rank;
    public ScoreGrade scoreGrade;

    public ScoreGradeValue(int _rank, ScoreGrade _scoreGrade)
    {
        rank = _rank;
        scoreGrade = _scoreGrade;
    }
}

public enum ScoreGrade
{
    A_PLUS,
    A,
    A_MINUS,
    B_PLUS,
    B,
    B_MINUS,
    C_PLUS,
    C,
    C_MINUS,
    D
}