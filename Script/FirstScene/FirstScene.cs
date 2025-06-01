using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class FirstScene : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void DeleteGetParameter();

    [DllImport("__Internal")]
    private static extern bool IsMobileDevicePlatform();

    private bool isStarted = false;

    void Start()
    {
        // int targetWidth = 1920;
        // int targetHeight = 1080;
        // bool fullscreen = false;

        // Screen.SetResolution(targetWidth, targetHeight, fullscreen);
        if (RuntimePlatform.WebGLPlayer == Application.platform)
        {
            string htmlUrl = Application.absoluteURL;
            string[] htmlUrls = htmlUrl.Split("token=");

            if (htmlUrls.Length > 0)
            {
                if (htmlUrls[1] != "")
                {
                    UserModel.Instance.AccessToken = htmlUrls[1];
                }
            }
            else
                UserModel.Instance.AccessToken = "";

            DeleteGetParameter();
        }

        if (RuntimePlatform.WindowsEditor == Application.platform)
            UserModel.Instance.devicePlatform = DevicePlatform.Pc;
        else if (RuntimePlatform.OSXEditor == Application.platform)
            UserModel.Instance.devicePlatform = DevicePlatform.Pc;
        else if (IsMobileDevicePlatform())
            UserModel.Instance.devicePlatform = DevicePlatform.Mobile;
        else
            UserModel.Instance.devicePlatform = DevicePlatform.Pc;

        StartCoroutine(AsyncScene());
    }

    IEnumerator AsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SceneLoader", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            if (!isStarted)
            {
                isStarted = true;
                SceneManager.LoadScene("GameStart");
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator AsyncSceneCurson()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Cursor", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            if (!isStarted)
            {
                isStarted = true;
                SceneManager.LoadScene("GameStart");
                yield break;
            }

            yield return null;
        }
    }
}
