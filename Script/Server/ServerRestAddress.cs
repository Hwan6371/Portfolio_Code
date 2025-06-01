using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServerRestAddress
{
    // TEST
    public const string POST_TEST_TOKEN_ACCESS_TOKEN = Game_Name + "user-profile/dev/test/access-token";

    // ERROR
    public const string POST_ERROR_LOG = "https://POST_ERROR_LOG";

    // BASE
    public const string PRODUCT_SERVER_ADDRESS = "https://PRODUCT_SERVER_ADDRESS/api/v1/";
    public const string DEV_SERVER_ADDRESS = "https://DEV_SERVER_ADDRESS/api/v1/";
    
    // GET
    public const string GET_GAME_QUIZ_INFO = Game_Name;
    public const string GET_GAME_START = Game_Name + Executed_Info + "start";    
    public const string GET_SCORE = Game_Name + Executed_Info + "score";
    public const string GET_USER_CHECK = "web-mini-game/dev/test/user-check";

    // POST
    public const string POST_GAME_DATA_SAVE = "web-mini-game/scores";
    
    // PUT
    public const string PUT_GAME_END = Game_Name + "executed-info/end";

    public const string PUT_PING = "miniGame/game-content/profile/";
    public const string PUT_PING_TAIL = "ping";

    // URLComponentType
    private const string Game_Name = "web-mini-game/";
    public const string Executed_Info = "executed-info/";
    public const string DeviceId = "deviceId";

    private static readonly Dictionary<ApiAddressType, string> subAddressMap = new()
    {
        { ApiAddressType.POST_ERROR_LOG, POST_ERROR_LOG },

        { ApiAddressType.GET_GAME_QUIZ_INFO, GET_GAME_QUIZ_INFO },
        { ApiAddressType.GET_GAME_START, GET_GAME_START },        
        { ApiAddressType.GET_SCORE, GET_SCORE },
        
        { ApiAddressType.POST_GAME_DATA_SAVE, POST_GAME_DATA_SAVE },

        { ApiAddressType.PUT_GAME_END, PUT_GAME_END },

        { ApiAddressType.GET_USER_CHECK, GET_USER_CHECK },
         
         // !! TEST CODE 토큰 가져오기
        { ApiAddressType.POST_TEST_TOKEN_ACCESS_TOKEN, POST_TEST_TOKEN_ACCESS_TOKEN },        

        // !! PUT - 예시
        { ApiAddressType.PUT_PING, PUT_PING },
        { ApiAddressType.PUT_PING_TAIL, PUT_PING_TAIL },
        
        // !! URLComponentType - 예시
        { ApiAddressType.Executed_Info, Executed_Info },
        { ApiAddressType.DeviceId, DeviceId },
    };

    public static string GetAddress(ApiAddressType _apiAddressType, ApiAddressType _apiAddressTypeTail = ApiAddressType.NONE, List<AdditionalApiInfo> _additionalInfos = null)
    {
        if (_apiAddressType == ApiAddressType.POST_ERROR_LOG)
            return POST_ERROR_LOG;

        string address = Debug.isDebugBuild ? DEV_SERVER_ADDRESS : PRODUCT_SERVER_ADDRESS;
        string subAddress = GetSubAddress(_apiAddressType);

        if (_additionalInfos == null || !_additionalInfos.Any())
            return string.Format("{0}{1}", address, subAddress);

        var pathVariables = new List<string>();
        var queryParameters = new List<string>();

        foreach (var additionalInfo in _additionalInfos)
        {
            if (additionalInfo.urlComponentType == URLComponentType.PathVariable)
                pathVariables.Add($"{GetSubAddress(additionalInfo.apiAddressType)}{additionalInfo.value}");
            else if (additionalInfo.urlComponentType == URLComponentType.QueryParameter)
                queryParameters.Add($"{GetSubAddress(additionalInfo.apiAddressType)}={additionalInfo.value}");
        }

        string pathWithVariables = "";
        if (pathVariables.Count != 0)
            pathWithVariables = string.Join("/", pathVariables);

        string queryString = "";
        if (queryParameters.Count != 0)
            queryString = queryParameters.Any() ? "?" + string.Join("&", queryParameters) : "";

        string subTailAddress = "";
        if (_apiAddressTypeTail != ApiAddressType.NONE)
            subTailAddress = "/" + GetSubAddress(_apiAddressTypeTail);

        return string.Format("{0}{1}{2}{3}{4}", address, subAddress, pathWithVariables, subTailAddress, queryString);
    }

    private static string GetSubAddress(ApiAddressType _apiAddressType)
    {
        if (subAddressMap.TryGetValue(_apiAddressType, out string subAddress))
            return subAddress;

        Debug.LogWarning("GetSubAddress Error");
        return "default_sub_address";
    }
}

public class AdditionalApiInfo
{
    public ApiAddressType apiAddressType;
    public string value;
    public URLComponentType urlComponentType;
}

