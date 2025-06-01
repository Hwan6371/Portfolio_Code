using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHouseItem : MonoBehaviour
{
    public bool isOnlyTrigger = false;
    public string point = "0";

    public SpriteRenderer lineSpriteRenderer;
    public SpriteRenderer houseSpriteRenderer;

    public GameObject houseObject;

    [Header("Lines")]
    public Sprite sprite_NULL;
    public Sprite sprite_LEFT_TO_RIGHT;
    public Sprite sprite_RIGHT_TO_LEFT;

    [Header("Houses")]
    public Sprite sprite_COLOR_CAT;
    public Sprite sprite_COLOR_FROG;
    public Sprite sprite_COLOR_HAMSTER;
    public Sprite sprite_COLOR_LION;
    public Sprite sprite_COLOR_RABBIT;

    public Sprite sprite_SHADOW_CAT;
    public Sprite sprite_SHADOW_FROG;
    public Sprite sprite_SHADOW_HAMSTER;
    public Sprite sprite_SHADOW_LION;
    public Sprite sprite_SHADOW_RABBIT;

    public List<GameObject> monsterGameObjects;

    [SerializeField] private int lineNumber;

    private NewHouseType newHouseType;

    public int GetLineNumber()
    {
        return lineNumber;
    }

    public NewHouseType GetNewHouseType()
    {
        return newHouseType;
    }

    public void OpenHouse()
    {
        monsterGameObjects = new();
        houseObject.SetActive(true);
    }

    public void CloseHouse()
    {
        houseObject.SetActive(false);
    }

    public void SetHouse(NewHouseType _newHouseType)
    {
        switch (_newHouseType)
        {
            case NewHouseType.COLOR_CAT:
                houseSpriteRenderer.sprite = sprite_COLOR_CAT;
                break;
            case NewHouseType.COLOR_FROG:
                houseSpriteRenderer.sprite = sprite_COLOR_FROG;
                break;
            case NewHouseType.COLOR_HAMSTER:
                houseSpriteRenderer.sprite = sprite_COLOR_HAMSTER;
                break;
            case NewHouseType.COLOR_LION:
                houseSpriteRenderer.sprite = sprite_COLOR_LION;
                break;
            case NewHouseType.COLOR_RABBIT:
                houseSpriteRenderer.sprite = sprite_COLOR_RABBIT;
                break;

            case NewHouseType.SHADOW_CAT:
                houseSpriteRenderer.sprite = sprite_SHADOW_CAT;
                break;
            case NewHouseType.SHADOW_FROG:
                houseSpriteRenderer.sprite = sprite_SHADOW_FROG;
                break;
            case NewHouseType.SHADOW_HAMSTER:
                houseSpriteRenderer.sprite = sprite_SHADOW_HAMSTER;
                break;
            case NewHouseType.SHADOW_LION:
                houseSpriteRenderer.sprite = sprite_SHADOW_LION;
                break;
            case NewHouseType.SHADOW_RABBIT:
                houseSpriteRenderer.sprite = sprite_SHADOW_RABBIT;
                break;

            default:
                break;
        }

        newHouseType = _newHouseType;
    }

    private void Start()
    {
        if(isOnlyTrigger)
            return;

        switch (point)
        {
            case "0":
                gameObject.transform.localPosition = new Vector3(-9.688f, -0.185f, -1f);
                break;
            case "1":
                gameObject.transform.localPosition = new Vector3(-6.912f, -0.185f, -1f);
                break;
            case "2":
                gameObject.transform.localPosition = new Vector3(-4.15f, 0f, -1f);
                break;
            case "3":
                gameObject.transform.localPosition = new Vector3(-1.383f, 0f, -1f);
                break;
            case "4":
                gameObject.transform.localPosition = new Vector3(1.383f, 0f, -1f);
                break;
            case "5":
                gameObject.transform.localPosition = new Vector3(4.15f, 0f, -1f);
                break;
            case "6":
                gameObject.transform.localPosition = new Vector3(6.912f, -0.185f, -1f);
                break;
            case "7":
                gameObject.transform.localPosition = new Vector3(9.688f, -0.185f, -1f);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            if(other.gameObject.GetComponent<NewMonsterView>().GetLineNumber() == lineNumber)
            {
                monsterGameObjects.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            if(other.gameObject.GetComponent<NewMonsterView>().GetLineNumber() == lineNumber)
            {
                RemoveFirstMonsterObject();
            }
        }
    }

    public GameObject GetGameObject()
    {
        if(monsterGameObjects.Count > 0)
            return monsterGameObjects[0];
        else
            return null;
    }

    public void RemoveFirstMonsterObject()
    {
        monsterGameObjects.RemoveAt(0);
    }
}