using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PopupManager : MonoBehaviour
{
    public GameObject popup;

    public void OpenError()
    {
        Time.timeScale = 0;
        popup.SetActive(true);
    }
}
