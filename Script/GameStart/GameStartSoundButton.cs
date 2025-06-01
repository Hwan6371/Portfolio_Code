using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartSoundButton : MonoBehaviour
{
    [SerializeField] private Sprite spriteOn;
    [SerializeField] private Sprite spriteOff;
    [SerializeField] private Image soundImage;

    private OnOff onOff = OnOff.On;

    private void Start() 
    {
        if(AudioListener.volume == 0)
            onOff = OnOff.Off;
            
        UpdateSoundImage();
    }

    public void OnClickOnOff()
    {
        ToggleSound();
        UpdateSoundImage();
        SetSoundState();
    }

    private void ToggleSound()
    {
        onOff = (onOff == OnOff.On) ? OnOff.Off : OnOff.On;
    }

    private void UpdateSoundImage()
    {
        soundImage.sprite = (onOff == OnOff.On) ? spriteOn : spriteOff;
    }

    private void SetSoundState()
    {
        AudioListener.volume = (onOff == OnOff.On) ? 1f : 0f;
    }

    private enum OnOff
    {
        On,
        Off
    }
}
