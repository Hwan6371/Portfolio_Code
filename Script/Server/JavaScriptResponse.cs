using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaScriptResponse : MonoBehaviour
{
    public GameObject testObject;
    void Start()
    {
        
    }

    public void Test1()
    {
        testObject.SetActive(false);
    }

    public void Test2()
    {
        testObject.SetActive(true);
    }

}

