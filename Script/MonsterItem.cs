using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterItem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite whiteRabbit;
    public Sprite redRabbit;
    public Sprite blackDog;

    private MonsterType monsterType;
    private MonsterColor monsterColor;
    private MonsterForm monsterForm;

    private bool isTrigger = false;

    private int lineIndex = 0;

    public void SetSprite()
    {
        switch (monsterType)
        {
            case MonsterType.WhiteRabbit:
                spriteRenderer.sprite = whiteRabbit;
                monsterColor = MonsterColor.White;
                monsterForm = MonsterForm.Rabbit;
                break;
            case MonsterType.RedRabbit:
                spriteRenderer.sprite = redRabbit;
                monsterColor = MonsterColor.Red;
                monsterForm = MonsterForm.Rabbit;
                break;
            case MonsterType.BlackDog:
                spriteRenderer.sprite = blackDog;
                monsterColor = MonsterColor.Black;
                monsterForm = MonsterForm.Dog;
                break;
        }
    }

    public void SetMonsterType(MonsterType _monsterType)
    {
        monsterType = _monsterType;
    }

    public MonsterType GetMonsterType()
    {
        return monsterType;
    }

    public MonsterColor GetMonsterColor()
    {
        return monsterColor;
    }

    public MonsterForm GetMonsterForm()
    {
        return monsterForm;
    }

    public void SetLineIndex(int _index)
    {
        lineIndex = _index;
    }

    public int GetLineIndex()
    {
        return lineIndex;
    }

    public bool GetTrigger()
    {
        return isTrigger;
    }

    public void Init()
    {
        isTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Box"))
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Init();
        }
    }

    public void EndMove()
    {
        Init();
        gameObject.GetComponent<PathFollower>().EndMove();
    }
}