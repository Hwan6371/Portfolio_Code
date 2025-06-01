using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UIElements;

public class HomeBoundGameAction : MonoBehaviour
{
    public GameObject monsterLine;

    public HomeBoundManager homeBoundManager;

    private void Update() 
    {
        if (IsClickable())
            HandleClickEvent();
    }

    bool IsClickable()
    {
        return Input.GetMouseButtonDown(0);
    }

    void HandleClickEvent()
    {
        if (!TryGetHitObject(out RaycastHit2D hit))
            return;

        if(!IsBox(hit))
            return;

        OnClickEvent(hit);
    }

    bool TryGetHitObject(out RaycastHit2D hit)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        return hit.collider != null;
    }

    bool IsBox(RaycastHit2D hit)
    {
        if(hit.collider.CompareTag("Box"))
            return true;
        else
            return false;
    }

    private void OnClickEvent(RaycastHit2D hit)
    {
        BoxItem boxItem = hit.collider.GetComponent<BoxItem>();
        GameObject monsterObject = boxItem.GetGameObject();

        if(monsterObject == null)
            return;
        
        MonsterItem monsterItem = monsterObject.GetComponent<MonsterItem>();
        monsterItem.EndMove();
        homeBoundManager.CheckAnswer(boxItem.GetQuizType(), monsterItem.GetMonsterType(), boxItem.GetMonsterType(), monsterItem.GetMonsterColor(), boxItem.GetMonsterColor(), monsterItem.GetMonsterForm(), boxItem.GetMonsterForm());
    }

}