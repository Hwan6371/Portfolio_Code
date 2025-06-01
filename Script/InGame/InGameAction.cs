using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAction : MonoBehaviour
{
    public InGameManager inGameManager;

    public InGameView inGameView;

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

        if(!IsHouse(hit))
            return;

        OnClickEvent(hit);
    }

    bool TryGetHitObject(out RaycastHit2D hit)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        return hit.collider != null;
    }

    bool IsHouse(RaycastHit2D hit)
    {
        if(hit.collider.CompareTag("House"))
            return true;
        else if(hit.collider.CompareTag("Monster"))
            return true;
        else
            return false;
    }

    private void OnClickEvent(RaycastHit2D hit)
    {
        if(hit.collider.gameObject.transform.TryGetComponent<NewMonsterView>(out var newMonsterView))
        {
            if(newMonsterView.GetHouseObject() == null)
                return;

            inGameView.OnClickEvent(newMonsterView.gameObject, newMonsterView.GetNewMonsterType(), newMonsterView.GetNewHouseType(), newMonsterView.GetHouseObject());
            return;
        }

        if(!hit.collider.gameObject.transform.TryGetComponent<NewHouseItem>(out var newHouseItem))
            return;

        // if(newHouseItem.GetGameObject() != null)
        // {
        //     inGameView.OnClickEvent(newHouseItem.GetGameObject(), newHouseItem.GetGameObject().GetComponent<NewMonsterView>().GetNewMonsterType(), newHouseItem.GetNewHouseType(), newHouseItem.gameObject);
        // }
    }
}