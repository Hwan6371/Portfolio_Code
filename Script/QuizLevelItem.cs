using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizLevelItem : MonoBehaviour 
{
    public LineRenderer[] lineRenderers;

    public BoxItem[] boxItems;

    public int addMonsterLevel = 1;
    
    private void Start()
    {
        
    }

    public int GetAddMonsterLevel()
    {
        return addMonsterLevel;
    }

    public LineRenderer[] GetLineRenderers()
    {
        return lineRenderers;
    }

    public BoxItem[] GetBoxItems()
    {
        return boxItems;
    }
}