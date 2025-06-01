using System;
using System.Linq;

public enum NewHouseType
{
    COLOR_CAT,
    COLOR_FROG,
    COLOR_HAMSTER,
    COLOR_LION,
    COLOR_RABBIT,

    SHADOW_CAT,
    SHADOW_FROG,
    SHADOW_HAMSTER,
    SHADOW_LION,
    SHADOW_RABBIT,

    NULL
}

public class NewHouseTypeSelector
{
    private static Random random = new Random();

    public static NewHouseType GetRandomAnswerType(AnswerType answerType, NewHouseType excludeType = NewHouseType.NULL)
    {
        if (excludeType == NewHouseType.NULL)
        {
            var returnNewHouseType = answerType switch
            {
                AnswerType.COLOR => GetALLRandomType("COLOR_"),
                AnswerType.SHADOW => GetALLRandomType("SHADOW_"),
                _ => NewHouseType.NULL,
            };
            return returnNewHouseType;
        }
        else
        {
            var returnNewHouseType = answerType switch
            {
                AnswerType.COLOR => GetRandomType("COLOR_", excludeType),
                AnswerType.SHADOW => GetRandomType("SHADOW_", excludeType),
                _ => NewHouseType.NULL,
            };
            return returnNewHouseType;
        }
    }

    private static NewHouseType GetRandomType(string prefix, NewHouseType excludeType)
    {
        var allTypes = Enum.GetValues(typeof(NewHouseType)).Cast<NewHouseType>();

        string excludeBase = excludeType != NewHouseType.NULL
            ? excludeType.ToString().Split('_')[1]
            : string.Empty;

        var filteredTypes = allTypes
            .Where(t => t.ToString().StartsWith(prefix) && !t.ToString().Contains(excludeBase))
            .ToList();

        return filteredTypes[random.Next(filteredTypes.Count)];
    }

    public static NewHouseType GetRandomAnswerType(AnswerType answerType, NewHouseType excludeType1 = NewHouseType.NULL, NewHouseType excludeType2 = NewHouseType.NULL)
    {
        if (excludeType1 == NewHouseType.NULL && excludeType2 == NewHouseType.NULL)
        {
            var returnNewHouseType = answerType switch
            {
                AnswerType.COLOR => GetALLRandomType("COLOR_"),
                AnswerType.SHADOW => GetALLRandomType("SHADOW_"),
                _ => NewHouseType.NULL,
            };
            return returnNewHouseType;
        }
        else
        {
            var returnNewHouseType = answerType switch
            {
                AnswerType.COLOR => GetRandomType("COLOR_", excludeType1, excludeType2),
                AnswerType.SHADOW => GetRandomType("SHADOW_", excludeType1, excludeType2),
                _ => NewHouseType.NULL,
            };
            return returnNewHouseType;
        }
    }

    private static NewHouseType GetRandomType(string prefix, NewHouseType excludeType1, NewHouseType excludeType2)
    {
        var allTypes = Enum.GetValues(typeof(NewHouseType)).Cast<NewHouseType>();

        string excludeBase1 = excludeType1 != NewHouseType.NULL
            ? excludeType1.ToString().Split('_')[1]
            : string.Empty;

        string excludeBase2 = excludeType2 != NewHouseType.NULL
            ? excludeType2.ToString().Split('_')[1]
            : string.Empty;

        var filteredTypes = allTypes
            .Where(t => t.ToString().StartsWith(prefix) &&
                        !t.ToString().Contains(excludeBase1) &&
                        !t.ToString().Contains(excludeBase2))
            .ToList();

        if (!filteredTypes.Any())
            return NewHouseType.NULL; // 제외 조건에 맞는 값이 없을 경우 NULL 반환

        return filteredTypes[random.Next(filteredTypes.Count)];
    }

    private static NewHouseType GetALLRandomType(string prefix)
    {
        var allTypes = Enum.GetValues(typeof(NewHouseType)).Cast<NewHouseType>();

        var filteredTypes = allTypes
            .Where(t => t.ToString().StartsWith(prefix))
            .ToList();

        return filteredTypes[random.Next(filteredTypes.Count)];
    }
}