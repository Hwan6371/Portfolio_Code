using System;
using UnityEngine;

[SerializeField]
public class QuizInfoResponseModel
{
    public int idx;
    public int questionNumber;
    public string gameType;
    public string inGameStep;
    public string touchEffect;
    public int totalQuizCount;
    public int correctAnswerCount;
    public int timeLimit;
}

[SerializeField]
public class ExecutedInfoResponseModel
{
    public int idx;
}


[SerializeField]
public class ScroeReslutResponseModel
{
    public int result;
}

// [SerializeField]
// public class TestAccessTokenResponseModel
// {
//     public string token;
// }