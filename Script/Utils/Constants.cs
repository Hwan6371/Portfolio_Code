using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//임시로 사용할 문자열 정의 추후 구글시트 연동으로 영 / 한 적용필요
public static class Constants
{
    #region 로그인 페이지 -> help

    public const string LOGIN_HELP_PAGE1 = "K-PASS 검사로 확인한 개인의 특성과 능력을 극\n대화 하고, 최대한 활용하기 위해서는 <b>집중력 향상</b>\n<b>이 필수</b>입니다.";
    public const string LOGIN_HELP_PAGE2 = "집중력은 <b>0~25세까지 지속적인 훈련을 통해 향상</b>\n<b>가능</b>하며, <b>6개월 이상 꾸준히 훈련을 반복</b>하는 것이\n좋습니다.";
    public const string LOGIN_HELP_PAGE3 = "K-PASS 검사결과에서 주의력\n표준점수(지수)가 낮은 경우 집중력 미니게임을 통해\n<b>꾸준히 훈련을 반복</b>해보세요.";
    public const string LOGIN_HELP_PAGE4 = "ㆍ집중력 미니게임은 <b>K-PASS 검사를 완료한</b>\n    <b>프로필</b>에 한하여 <b>무료로 제공</b>됩니다.\nㆍK-PASS with ID 또는 소속 로그인 코드로\n    언제든지 미니게임을 이용할 수 있습니다.";


    #endregion

    #region 로그인 메인페이지 -> 로그인 프로세스 페이지

    public static SelectedLoginType SelectedLogin = SelectedLoginType.NONE;

    public const string LOGIN_ORGAN_CODE_ERROR_NO_INOUT = "로그인코드를 입력해주세요.";
    public const string LOGIN_ORGAN_CODEINFO = "<b>소속 로그인코드 6자리를 입력해주세요!</b>\n코드가 없을 경우, K-PASS with 회원 로그인으로 진행\n해주세요.";
    public const string LOGIN_ORGAN_MEMBERINFO = "<b>입력한 소속로그인코드의 멤버 이름을 입력해주세요.</b>\n설정된 이름은[K - PASS with 앱] 또는 소속관리자에게서\n확인가능합니다.";

    public const string LOGIN_ORGAN_NAME_ERROR_5TIME = "이름을 잘못입력하셨습니다.(5/5회) 아래 취소버튼을 통해 다시 시도해주세요.";
    public const string LOGIN_ORGAN_NAME_ERROR_NO_INOUT = "이름을 입력해주세요.";
    public const string LOGIN_ORGAN_NAME_ERROR_WRONG = "이름을 잘못입력하셨습니다.";


    public const string LOGIN_WITH_EMAIL_INFO = "<b>K-PASS with 앱에서 가입한 이메일을 입력해주세요!</b>\n회원가입은 K-PASS with 앱에서 진행해주세요.";
    public const string LOGIN_WITH_CHOOSE_AUTH_INFO = "<b>로그인 인증 방식을 선택해주세요.</b>\n등록된 번호가 다를 경우 이메일 인증을 해주시고,\nK-PASS with App에서 회원정보를 수정해 주세요.";
    public const string LOGIN_WITH_CHOOSE_AUTH_PHONE_INFO = "휴대폰 인증 ";
    public const string LOGIN_WITH_CHOOSE_AUTH_EMAIL_INFO = "이메일 인증 ";

    public const string LOGIN_WITH_INPUT_AUTH_PHONE_INFO = "위 번호로 받으신 인증코드를 입력해주세요!\n인증 코드를 받지 못한 경우 스팸 메시지를 확인해주세요.";
    public const string LOGIN_WITH_INPUT_AUTH_EMAIL_INFO = "위 메일을 확인하여 인증코드를 입력해주세요!";

    public const string LOGIN_WITH_EMAIL_ERROR_NO_INPUT = "이메일을 입력해주세요.";
    public const string LOGIN_WITH_EMAIL_ERROR_WRONGTYPE = "잘못된 형식의 이메일주소입니다.다시 입력해주세요!";
    public const string LOGIN_WITH_EMAIL_ERROR_NO_USER = "가입되지 않은 이메일입니다.회원가입 후 이용해주세요!";
    public const string LOGIN_WITH_EMAIL_ERROR_COM_ERROR = "잠시후 시도해주세요.";

    public const string LOGIN_WITH_AUTH_ERROR_5TIME = "인증코드를 5회 잘못입력하셨습니다. 잠시후 시도해주세요.";
    public const string LOGIN_WITH_EMAIL_ERROR_LEAVE = "해당 계정은 이미 탈퇴한 계정입니다. 다른 이메일주소로 재시도해주세요.";
    public const string LOGIN_WITH_EMAIL_ERROR_BLOCK = "현재 차단된 계정입니다.";

    public const string LOGIN_WITH_CHOOSE_AUTH_ERROR_NO_CHOOSE = "인증 방식을 선택해주세요.";

    public const string LOGIN_WITH_AUTH_ERROR_NO_INPUT = "인증코드를 입력해주세요.";
    public const string LOGIN_WITH_AUTH_ERROR_WRONG_TYPE = "잘못된 인증 코드입니다. 다시 입력해주세요!";
    public const string LOGIN_WITH_AUTH_ERROR_WRONG = "인증코드를 잘못입력하셨습니다.";
    public const string LOGIN_WITH_AUTH_ERROR_WRONG_5TIME = "인증 코드를 잘못입력하셨습니다.(5/5회)\n아래 취소버튼을 통해 다시 시도해주세요.";
    public const string LOGIN_WITH_AUTH_ERROR_TIMEOUT = "입력시간이 초과된 코드입니다.\n아래 취소버튼을 통해 다시 시도해주세요.";
    public const string LOGIN_WITH_AUTH_ERROR_USED = "이미 로그인에 사용된 코드입니다.\n아래 취소버튼을 통해 다시 시도해주세요.";

    #endregion

}

