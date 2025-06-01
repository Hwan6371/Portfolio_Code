
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameDataRequestModel
{
    public int questionNumber { get; set; }
    public List<UserAnswersRequestModel> userAnswers { get; set; }
    public int executedInfoIdx { get; set; }
}

public class UserAnswersRequestModel
{
    public int answer { get; set; }
    public float elapsedTime { get; set; }
}

[Serializable]
public class WebRequestFormGameComplete
{
    public int contentExecutedIdx { get; set; }
}

[Serializable]
public class TestAccessTokenRequestModel
{
    public string userIdx;
}

[Serializable]
public class MiniGameScoresSaveRequestModel
{
    public int score;
    public string miniGameType;
}