using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDebugOn : MonoBehaviour
{
    void Start()
    {
        if(Debug.isDebugBuild)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    private void OnEnable() 
    {
        if(Debug.isDebugBuild)
            Invoke(nameof(SetAnswer), 2.0f);
    }

    public void SetAnswer()
    {
        
    }
}
