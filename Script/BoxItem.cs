using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxItem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite spriteDumy;

    public Sprite whiteRabbit;
    public Sprite redRabbit;
    public Sprite blackDog;

    public TextMeshPro testTextMeshPro;

    private MonsterType monsterType;    
    private MonsterColor monsterColor;
    private MonsterForm monsterForm;

    public QuizType quizType = QuizType.Both;

    public int lineIndex;

    public List<GameObject> monsterGameObjects;

    private void Start() 
    {
    }

    public void SetData()
    {
        switch (monsterType)
        {
            case MonsterType.WhiteRabbit:
                // spriteRenderer.sprite = whiteRabbit;
                testTextMeshPro.text = "white\nRabbit";
                monsterColor = MonsterColor.White;
                monsterForm = MonsterForm.Rabbit;
                break;
            case MonsterType.RedRabbit:
                // spriteRenderer.sprite = redRabbit;
                testTextMeshPro.text = "red\nRabbit";
                monsterColor = MonsterColor.Red;
                monsterForm = MonsterForm.Rabbit;
                break;
            case MonsterType.BlackDog:
                // spriteRenderer.sprite = redRabbit;
                testTextMeshPro.text = "black\nDog";
                monsterColor = MonsterColor.Black;
                monsterForm = MonsterForm.Dog;
                break; 
        }
    }

    public void SetMonsterType()
    {
        var enumValues = System.Enum.GetValues(enumType: typeof(MonsterType));
        monsterType = (MonsterType)enumValues.GetValue(Random.Range(0, enumValues.Length));
        SetData();
    }

    public MonsterColor GetMonsterColor()
    {
        return monsterColor;
    }

    public MonsterForm GetMonsterForm()
    {
        return monsterForm;
    }


    public MonsterType GetMonsterType()
    {
        return monsterType;
    }

    public QuizType GetQuizType()
    {
        return quizType;
    }
   
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            monsterGameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            RemoveFristMonsterObject();
        }
    }

    public GameObject GetGameObject()
    {
        if(monsterGameObjects.Count > 0)
            return monsterGameObjects[0];
        else
            return null;
    }

    public void RemoveFristMonsterObject()
    {
        monsterGameObjects.RemoveAt(0);
    }
}