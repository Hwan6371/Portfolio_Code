using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class SceneLoaderView : MonoBehaviour
{
    public GameObject guideObject;
    public Image guideProgressImage;

    public PlayableDirector loadingPlayableDirector;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        guideProgressImage.fillAmount = 0;
    }

    public void CloseSceneLoading()
    {
        guideProgressImage.fillAmount = 1.0f;        
        guideObject.SetActive(false);
        loadingPlayableDirector.Stop();
    }

    public void OpenSceneLoading()
    {
        guideProgressImage.fillAmount = 0;
        guideObject.SetActive(true);
        // loadingPlayableDirector.time = 15.5f;
        loadingPlayableDirector.time = 0f;
        loadingPlayableDirector.Play();
    }

    public void SetProgress(float _value)
    {
        guideProgressImage.fillAmount = _value;
    }

}
