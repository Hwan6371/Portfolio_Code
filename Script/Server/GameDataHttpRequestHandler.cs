using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

public class GameDataHttpRequestHandler
{
    public UnityWebRequest unityWebRequest { get; set; }
    public string json;

    public GameDataHttpRequestHandler(int _chapter, string _answerType, List<GameDataRequestModel> _gameDataModels)
    {
        // if (UserModel.Instance.GetProfile() == null && Debug.isDebugBuild)
        //     return;

        // GameDataUserModel gameDataUserModel = new()
        // {
        //     contentExecutedInfoIdx = UserModel.Instance.GetProfile().gameIdx,
        //     chapter = _chapter,
        //     isSaveOnlyAnswer = false,
        //     deviceId = SystemInfo.deviceUniqueIdentifier,
        //     answerType = _answerType.ToString(),

        //     questionNumber = GetPropertyValues(_gameDataModels, model => model.questionNumber),
        //     errorCnt = GetPropertyValues(_gameDataModels, model => model.errorCnt),
        //     userAnswer = GetPropertyValues(_gameDataModels, model => model.userAnswer),
        //     isCorrectAnswer = GetPropertyValues(_gameDataModels, model => model.isCorrectAnswer),
        //     elapsedTime = GetPropertyValues(_gameDataModels, model => model.elapsedTime),
        //     isTimeOvers = GetPropertyValues(_gameDataModels, model => model.isTimeOvers),
        //     sceneCutNumb = GetPropertyValues(_gameDataModels, model => model.sceneCutNumb)
        // };

        // json = JsonConvert.SerializeObject(gameDataUserModel);
        // Debug.Log(json);

        // unityWebRequest = new UnityWebRequest();

        // Debug.Log(new RESTAPIService().GetAddress(COMMUNICATION_TYPE.POST_GAME_DATA_SAVE));
        // unityWebRequest = UnityWebRequest.PostWwwForm(new RESTAPIService().GetAddress(COMMUNICATION_TYPE.POST_GAME_DATA_SAVE), json);
    }

    public GameDataHttpRequestHandler()
    {
        WebRequestFormGameComplete webRequestFormGameComplete = new()
        {
            // contentExecutedIdx = UserModel.Instance.GetProfile().gameIdx
        };

        json = JsonConvert.SerializeObject(webRequestFormGameComplete);

        unityWebRequest = new UnityWebRequest();
        // unityWebRequest = UnityWebRequest.Put(new RESTAPIService().GetAddress(COMMUNICATION_TYPE.PUT_GAME_COMPLETE, UserModel.Instance.GetProfile().gameIdx + ConstRESTAPI.PUT_GAME_COMPLETE_POSTFIX), json);
    }

    private List<TProperty> GetPropertyValues<TModel, TProperty>(List<TModel> models, Func<TModel, TProperty> selector)
    {
        return models.Select(selector).ToList();
    }
}
