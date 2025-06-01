using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NewMonsterItem
{
    public NewMonsterType newMonsterType;
}

public enum NewMonsterType
{
    CAT,
    FROG,
    HAMSTER,
    LION,
    RABBIT,
    BLANK
}

public class MonsterItemGenerator
{
    private static Random random = new Random();    

    public List<NewMonsterItem> GenerateMonsterItems(Dictionary<NewMonsterType, int> specificTypesWithCounts)
    {
        List<NewMonsterItem> newMonsterItems;

        newMonsterItems = new List<NewMonsterItem>();
        foreach (var pair in specificTypesWithCounts)
        {
            NewMonsterType type = pair.Key;
            int count = pair.Value;

            for (int i = 0; i < count; i++)
            {
                newMonsterItems.Add(CreateMonsterItem(type));
            }
        }

        int blankCount = random.Next(0, 3); // 0 ~ 2 // BLANK 추가공간
        for (int i = 0; i < blankCount; i++)
        {
            newMonsterItems.Add(CreateMonsterItem(NewMonsterType.BLANK));
        }

        int remainingCount = 27 - newMonsterItems.Count;
        NewMonsterType[] availableTypes = { NewMonsterType.CAT, NewMonsterType.FROG, NewMonsterType.HAMSTER, NewMonsterType.LION, NewMonsterType.RABBIT };

        for (int i = 0; i < remainingCount; i++)
        {
            NewMonsterType randomType = availableTypes[random.Next(availableTypes.Length)];

            while (specificTypesWithCounts.ContainsKey(randomType))
            {
                randomType = availableTypes[random.Next(availableTypes.Length)];
            }

            newMonsterItems.Add(CreateMonsterItem(randomType));
        }

        Shuffle(newMonsterItems);

        return newMonsterItems;
    }

    private NewMonsterItem CreateMonsterItem(NewMonsterType type)
    {
        NewMonsterItem newMonsterItem = new NewMonsterItem();
        newMonsterItem.newMonsterType = type;
        return newMonsterItem;
    }

    private void Shuffle(List<NewMonsterItem> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            NewMonsterItem temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}