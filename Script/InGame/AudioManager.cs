using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM_audioSource;
    public AudioSource O_audioSource;
    public AudioSource X_audioSource;

    public AudioSource StartStop_audioSource;
    public AudioSource StageChange_audioSource;

    public AudioSource Effect_audioSource;

    public void PlayAudio(EnumAudio _enumAudio)
    {
        switch (_enumAudio)
        {
            case EnumAudio.InGameBGM:
                BGM_audioSource.Play();
                break;
            case EnumAudio.O:
                O_audioSource.Play();
                break;
            case EnumAudio.X:
                X_audioSource.Play();
                break;
            case EnumAudio.InGameEffect:
                Effect_audioSource.Play();
                break;
            case EnumAudio.StartStop:                
                StartCoroutine(WaitCoroutine(()=> 
                { 
                    StartStop_audioSource.Play();
                } , 0.2f));

                break;
            case EnumAudio.StageChange:
                StageChange_audioSource.Play();
                break;
            default:
                break;
        }
    }

    IEnumerator WaitCoroutine(Action _action, float _time)
    {
        yield return new WaitForSeconds(_time);
        _action.Invoke();
    }
}

public enum EnumAudio
{
    InGameBGM,
    O,
    X,
    InGameEffect,
    StartStop,
    StageChange
}