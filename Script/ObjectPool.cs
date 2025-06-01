using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject poolParentObject;
    public int itemCount = 0;
    public GameObject monsterItem;

    public GameObject line1;
    public GameObject line2;
    public GameObject line3;

    public InGameView inGameView;

    private void Start() 
    {
        for(int i = 0; i < itemCount; i++)
        {
            GameObject itemGameObject = Instantiate(monsterItem);
            itemGameObject.transform.parent = poolParentObject.transform;
            itemGameObject.SetActive(false);
        }
    }

    public GameObject GetGameObject()
    {
        if(poolParentObject.transform.childCount == 0)
        {
            GameObject itemGameObject = Instantiate(monsterItem);
            itemGameObject.transform.parent = poolParentObject.transform;
        }

        poolParentObject.transform.GetChild(0).gameObject.SetActive(true);
        return poolParentObject.transform.GetChild(0).gameObject;
    }

    public void SetLineGameObject(int _line)
    {
        switch (_line)
        {
            case 1:
                poolParentObject.transform.GetChild(0).gameObject.transform.parent = line1.transform;
                break;
            case 2:
                poolParentObject.transform.GetChild(0).gameObject.transform.parent = line2.transform;
                break;
            case 3:
                poolParentObject.transform.GetChild(0).gameObject.transform.parent = line3.transform;
                break;
            default:
                break;
        }
    }

    public void SetPoolGameObject(GameObject _gameObject)
    {
        _gameObject.transform.parent = poolParentObject.transform;
    }    
}
