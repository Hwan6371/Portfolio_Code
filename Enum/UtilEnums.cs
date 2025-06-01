using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonState 
{
   NORMAL,
   HOVER,
   PRESS
}

public enum HelpEventTabState
{
    HELP,
    EVENT,
    FOCUS,
    NONE
}

public enum OrganLoginState
{
    NONE,
    ORGAN_CODE,
    ORGAN_NAME,
    ORGAN_5WRONGS
}

public enum WithLoginState
{
    NONE,
    WITH_INPUT_EMAIL,
    WITH_CHOOSE_AUTH,
    WITH_INPUT_AUTH_PHONE,
    WITH_INPUT_AUTH_EMAIL,
    WITH_5ERROR
}

public enum SelectedLoginType
{
    NONE,
    WITH,
    ORGAN
}

public enum ImageErrorType
{
    NONE,
    NOW_LOADING,
    EMPTY_RESOURCE,
    NO_CURRENT_BACKGROUND,
    COMPLETE
}
