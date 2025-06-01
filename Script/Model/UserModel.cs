using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserModel
{
    private static UserModel instance;
    public static UserModel Instance
    {
        get
        {
            instance ??= new UserModel();

            return instance;
        }
    }
    
    public string AccessToken = "";
    public int executed_info = 0;

    public DevicePlatform devicePlatform = DevicePlatform.NONE;

    // public string AccessToken
    // {
    //     get
    //     {
    //         if (selectedProfile == null)
    //             return accessToken;

    //         return selectedProfile.token;
    //     }
    // }

    // private string accessToken = "";
    // private string refreshToken = "";
    // private List<ProfileModel> profiles = new List<ProfileModel>();
    // private ProfileModel selectedProfile = null;
    // private string withParentAccessToken = "";
    // private string withParentRefreshToken = "";


}

public enum DevicePlatform
{
    NONE,
    Mobile,
    Pc,
}
