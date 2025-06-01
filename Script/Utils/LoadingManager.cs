using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingImages;
    public PlayableDirector playableDirector;

    public void StartNetworkLoading()
    {
        playableDirector.Play();
        loadingImages.SetActive(true);
    }

    public void StopNetworkLoading()
    {        
        playableDirector.Stop();
        loadingImages.SetActive(false);
    }
}
