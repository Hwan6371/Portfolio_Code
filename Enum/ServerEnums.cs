public enum ApiAddressType
{
    NONE,
    POST_ERROR_LOG,
    POST_GAME_DATA_SAVE,
    GET_GAME_QUIZ_INFO,
    GET_GAME_START,
    PUT_GAME_END,
    GET_SCORE,
    POST_TEST_TOKEN_ACCESS_TOKEN,
    GET_USER_CHECK,
    PUT_PING,
    PUT_PING_TAIL,
    Executed_Info,
    DeviceId
}

public enum HttpMethod
{
    POST,
    GET,
    PUT,
    DELETE
}

public enum URLComponentType
{
    PathVariable,
    QueryParameter
}