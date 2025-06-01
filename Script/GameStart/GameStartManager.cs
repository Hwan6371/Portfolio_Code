using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    public Image soundImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    public TMP_Text versionText;

    public PlayableDirector animalsPlayableDirector;
    public PlayableDirector buttonPlayableDirector;

    private bool isStart = false;

    void Start()
    {
        if(JaeHwanUtils.Instance.cursorManager == null)
            JaeHwanUtils.Instance.cursorManager = GameObject.Find("SceneLoaderManager").GetComponent<CursorManager>();
        
        if(JaeHwanUtils.Instance.sceneLoaderManager == null)
            JaeHwanUtils.Instance.sceneLoaderManager = GameObject.Find("SceneLoaderManager").GetComponent<SceneLoaderManager>();

        if(JaeHwanUtils.Instance.loadingManager == null)
            JaeHwanUtils.Instance.loadingManager = GameObject.Find("LoadingManager").GetComponent<LoadingManager>();

        if(JaeHwanUtils.Instance.popupManager == null)
            JaeHwanUtils.Instance.popupManager = GameObject.Find("PopupManager").GetComponent<PopupManager>();

        JaeHwanUtils.Instance.sceneLoaderManager.LoadingCompleteAction(Play);
        JaeHwanUtils.Instance.sceneLoaderManager.SetAddressableLoadingState(AddressableLoadingState.END);
        
        JaeHwanUtils.Instance.cursorManager.SetCursor();

        JaeHwanUtils.Instance.sceneLoaderManager.PlayBgm(SceneName.GameStart);

        versionText.text = "v." + Application.version;

        SetSoundImage();

        animalsPlayableDirector.Play();
        
        isStart = false;

        buttonPlayableDirector.Play();

        StartCoroutine(WaitCoroutine(()=> { 
            isStart = true;
        } , 2.0f));


        // UserModel.Instance.AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJyb2xlIjoiVVNFUl9QUk9GSUxFIiwidXNlcklkeCI6IjEiLCJleHAiOjE3MzM4OTQ3MTMsImlhdCI6MTczMzg3MzExMywiand0VHlwZSI6ImFjY2VzcyJ9.5Dtqf2a4thctN-wJVhyD89DWs1xpESAcYMdeWElDGfwm63DaPH-Rf9OWnEFkP0sZJv4eKwk-FymjlJX6IqlSIg";
        // CheckToken(() => {
            
        // });
        // TestToken(() => {});
    }

    private void SetSoundImage()
    {
        if(JaeHwanUtils.Instance.soundOnOff)
            soundImage.sprite = soundOnSprite;
        else
            soundImage.sprite = soundOffSprite;
    }

    public void SetSound()
    {
        JaeHwanUtils.Instance.soundOnOff = !JaeHwanUtils.Instance.soundOnOff;

        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;

        SetSoundImage();
    }

    private void Play()
    {
        StartCoroutine(WaitCoroutine(()=> { JaeHwanUtils.Instance.sceneLoaderManager.CloseSceneLoading(); } , 2.5f));
    }

    IEnumerator WaitCoroutine(Action _action, float _time)
    {
        yield return new WaitForSeconds(_time);
        _action.Invoke();
    }

    private void TestToken(Action _action)
    {
        TestAccessTokenRequestModel testAccessTokenRequestModel = new()
        {
            userIdx = "1"
        };

        JaeHwanUtils.Instance.serverRestApi.SendRequest_POST(ApiAddressType.POST_TEST_TOKEN_ACCESS_TOKEN, testAccessTokenRequestModel, (json, errorMessage) =>
        {
            UserModel.Instance.AccessToken = json;
            Debug.Log(json);
            _action?.Invoke();
        });
    }

    private void CheckToken(Action _action)
    {
        JaeHwanUtils.Instance.serverRestApi.SendRequest_GET(ApiAddressType.GET_USER_CHECK, ApiAddressType.NONE, null, (json, errorMessage) =>
        {
            UserModel.Instance.AccessToken = json;
            Debug.Log(json);

            if(json.ToString() == "1 USER_PROFILE")
            {
                
            }
            _action?.Invoke();
        });
    }

    private void LoadQuizInfos()
    {
        JaeHwanUtils.Instance.serverRestApi.SendRequest_GET(ApiAddressType.GET_GAME_QUIZ_INFO, ApiAddressType.NONE, null, (json, errorMessage) =>
        {
            Debug.Log(json);
        });  
    }

    public void GameStart()
    {
        if(isStart)
            JaeHwanUtils.Instance.sceneLoaderManager.LoadScene(SceneName.InGame);
    }

    public void MouseHover()
    {
        JaeHwanUtils.Instance.cursorManager.OnMouseHover();
    }

    public void MouseSelect()
    {
        JaeHwanUtils.Instance.cursorManager.OnMouseExit();
    }

    public void MouseExit()
    {
        JaeHwanUtils.Instance.cursorManager.OnMouseExit();
    }
}
