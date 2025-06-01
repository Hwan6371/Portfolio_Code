using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorParticle : MonoBehaviour
{
    public RectTransform mainCanvasRectTransform;
    public GameObject cursonMainGameObject;
    public Camera cursorCamera;

    private List<CursorModel> cursorModels = new();
    private int currentIndex = 0;
    private List<int> cursorNumbers = new();

    private class CursorModel
    {
        public Transform transform;
        // public UIParticle particleSystem;
    }

    private void Start()
    {
        foreach(Transform item in cursonMainGameObject.transform)
        {
            CursorModel cursonModel = new()
            {
                transform = item,
                // particleSystem = item.GetComponent<UIParticle>()
            };
            cursorModels.Add(cursonModel);
        }

        foreach (var _ in cursorModels)
        {
            cursorNumbers.Add(cursorNumbers.Count);
        }
    }

    bool IsClickable()
    {
        return Input.GetMouseButtonDown(0);
    }

    int GetNextIndex(int currentIndex)
    {
        int newIndex = (currentIndex + 1) % cursorNumbers.Count;
        return cursorNumbers[newIndex];
    }

    void Update()
    {
        if(!IsClickable())
            return;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(mainCanvasRectTransform, Input.mousePosition, null, out Vector2 localPoint))
        {
            // Debug.Log("클릭 localPoint" + localPoint);
            int objectIndex = cursorNumbers[currentIndex];
            cursorModels[objectIndex].transform.localPosition = localPoint;
            // cursorModels[objectIndex].particleSystem.Play();
            
            currentIndex = GetNextIndex(currentIndex);
        }
    }
}
