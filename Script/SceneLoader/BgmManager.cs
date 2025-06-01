using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public AudioSource uiAudioSource;

    public AudioSource inGameAudioSource;

    public void StopAllAudios()
    {
        uiAudioSource.Stop();
        inGameAudioSource.Stop();
    }

    public void PlayBgm(SceneName _sceneName)
    {
        if( _sceneName == SceneName.InGame)
        {
            inGameAudioSource.Play();
            return;
        }

        uiAudioSource.Play();
    }
}
