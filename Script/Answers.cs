using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System;

public class Answers : MonoBehaviour
{
    public List<AnswerClass> answerList;
    private const int MaxMonster = 25;

    private void Start()
    {

        GetSetAnswer();
        string sJson = JsonConvert.SerializeObject(answerList);
        Debug.Log(sJson);

       // !! TestCode 
        // for (int i = 0; i < 10; i++)
        // {
        //     SetAnswer();
        //     string sJson = JsonConvert.SerializeObject(answerList);
        //     Debug.Log(sJson);

        //     // TestCode(answerList);    
        // }
    }

    public List<AnswerClass> GetSetAnswer()
    {
        answerList = new();
        MonsterItemGenerator monsterItemGenerator = new();


        // 1번 
        #region 1번
        AnswerClass answerClass = new()
        {
            mainIndex = 1,
            answerValueCount = 10
        };

        AnswerLine answerLine = new();

        answerLine.newHousePositions.Add(5);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR));

        answerLine.lineDirection = LineDirection.LeftToRight;

        Dictionary<NewMonsterType, int> specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine
        };

        answerList.Add(answerClass);
        #endregion

        // 2번
        #region 2번
        answerClass = new()
        {
            mainIndex = 2,
            answerValueCount = 10
        };

        answerLine = new();

        answerLine.newHousePositions.Add(2);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR));

        answerLine.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine
        };

        answerList.Add(answerClass);
        #endregion

        // 3번
        #region 3번
        answerClass = new()
        {
            mainIndex = 3,
            answerValueCount = 7
        };

        //3번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(2);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //3번 아랫라인
        AnswerLine answerLine2 = new();

        answerLine2.newHousePositions.Add(5);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR, answerLine.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 4번
        #region 4번
        answerClass = new()
        {
            mainIndex = 4,
            answerValueCount = 7
        };

        //4번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(5);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //4번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(2);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR, answerLine.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 5번
        #region 5번
        answerClass = new()
        {
            mainIndex = 5,
            answerValueCount = 10
        };

        //5번 라인
        answerLine = new();

        answerLine.newHousePositions.Add(5);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine
        };

        answerList.Add(answerClass);
        #endregion

        // 6번
        #region 6번
        answerClass = new()
        {
            mainIndex = 6,
            answerValueCount = 10
        };

        //6번 라인
        answerLine = new();

        answerLine.newHousePositions.Add(2);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW));
        answerLine.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine
        };

        answerList.Add(answerClass);
        #endregion

        // 7번
        #region 7번
        answerClass = new()
        {
            mainIndex = 7,
            answerValueCount = 7
        };

        //7번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(2);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //7번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(5);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW, answerLine.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 8번
        #region 8번
        answerClass = new()
        {
            mainIndex = 8,
            answerValueCount = 7
        };

        //8번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(5);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //8번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(2);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW, answerLine.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 9번
        #region 9번
        answerClass = new()
        {
            mainIndex = 9,
            answerValueCount = 7
        };

        //9번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(2);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR));
        answerLine.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //9번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(5);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW, answerLine.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 10번
        #region 10번
        answerClass = new()
        {
            mainIndex = 10,
            answerValueCount = 7
        };

        //10번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(5);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //10번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(2);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR, answerLine.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 11번
        #region 11번
        answerClass = new()
        {
            mainIndex = 11,
            answerValueCount = 6
        };

        //11번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(2);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR));
        answerLine.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //11번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(3);
        answerLine2.newHousePositions.Add(5);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW, answerLine.newHouseTypes[0]));
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW, answerLine.newHouseTypes[0], answerLine2.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount },
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[1]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        // 12번
        #region 12번
        answerClass = new()
        {
            mainIndex = 12,
            answerValueCount = 6
        };

        //12번 윗라인
        answerLine = new();

        answerLine.newHousePositions.Add(5);
        answerLine.newHouseTypes.Add(GetRandomAnswerType(AnswerType.SHADOW));
        answerLine.lineDirection = LineDirection.LeftToRight;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine.newHouseTypes[0]), answerClass.answerValueCount }
        };

        answerLine.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        //12번 아랫라인
        answerLine2 = new();

        answerLine2.newHousePositions.Add(2);
        answerLine2.newHousePositions.Add(4);
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR, answerLine.newHouseTypes[0]));
        answerLine2.newHouseTypes.Add(GetRandomAnswerType(AnswerType.COLOR, answerLine.newHouseTypes[0], answerLine2.newHouseTypes[0]));
        answerLine2.lineDirection = LineDirection.RightToLeft;

        specificTypesWithCounts = new Dictionary<NewMonsterType, int>
        {
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[0]), answerClass.answerValueCount },
            { GetConvertNewMonsterType(answerLine2.newHouseTypes[1]), answerClass.answerValueCount }
        };

        answerLine2.newMonsterItems = monsterItemGenerator.GenerateMonsterItems(specificTypesWithCounts);

        answerClass.answerLines = new()
        {
            answerLine,
            answerLine2
        };

        answerList.Add(answerClass);
        #endregion

        return answerList;
    }

    private void TestCode(List<AnswerClass> _answerList)
    {
        // mainIndex 올바른지?
        int testMainIndex = 0;
        foreach (var item in _answerList)
        {
            testMainIndex++;
            if(item.mainIndex != testMainIndex)
            {
                Debug.LogError("MainIndex Error");
                return;
            }
        }

        // 각 스테이지마다 NewHouseType이 다른 값인지 확인하는 코드
        List<NewHouseType> testNewHouseTypes = new();
        foreach (var item in _answerList)
        {
            testNewHouseTypes = new();
            foreach (var line in item.answerLines)
            {
                foreach (var newHouseType in line.newHouseTypes)
                {
                    testNewHouseTypes.Add(newHouseType);
                }
            }
            
            var duplicates = testNewHouseTypes
            .GroupBy(e => e)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

            if (duplicates.Any())
            {
                Debug.LogError("중복된 값이 있습니다: " + string.Join(", ", duplicates));
            }
        }

        // 각 라인마다 빈공간이 몇개인지 확인하는 코드
        foreach (var item in _answerList)
        {
            foreach (var line in item.answerLines)
            {
                int testBlankCount = 0;
                foreach (var newMonsterItem in line.newMonsterItems)
                {
                    if(newMonsterItem.newMonsterType == NewMonsterType.BLANK)
                    {
                        testBlankCount++;
                    }
                }
                if(testBlankCount > 2)
                {
                    Debug.LogError("빈 공간이 3개 이상한곳이 있습니다.");
                }
                // Debug.Log(testBlankCount);
            }
        }


        // 각 라인에 정답개수가 맞게 들어갔는지 확인하는 코드
        foreach (var item in _answerList)
        {
            foreach (var line in item.answerLines)
            {
                int testAnswerCount = 0;
                int answerValueCount = 0;
                foreach (var newMonsterItem in line.newMonsterItems)
                {
                    if(IsAnswerCheck(line.newHouseTypes, newMonsterItem.newMonsterType))
                    {
                        testAnswerCount++;
                    }
                }

                foreach (var newHouseType in line.newHouseTypes)
                {
                    answerValueCount += item.answerValueCount;
                }

                if(testAnswerCount != answerValueCount)
                {
                    Debug.LogError("정답 개수가 다릅니다." + testAnswerCount + " : " + answerValueCount);
                }
                // Debug.Log(testBlankCount);
            }
        }

        // 한 라인에 2개의 집이 중복되어 있는지 확인하는 코드
        foreach (var item in _answerList)
        {
            foreach (var line in item.answerLines)
            {
                if(line.newHouseTypes.Count > 1)
                {
                    if(HasDuplicates(line.newHouseTypes))
                    {
                        Debug.LogError("중복 발견");
                    }                
                }
            }
        }
    }

    private bool HasDuplicates<T>(List<T> enumList) where T : Enum
    {
        HashSet<T> set = new HashSet<T>();

        foreach (T item in enumList)
        {
            // HashSet에 이미 존재하면 중복된 값이 있는 것
            if (!set.Add(item))
            {
                return true; // 중복된 값이 존재
            }
        }
        return false; // 중복된 값이 없음
    }

    private bool IsAnswerCheck(List<NewHouseType> _newHouseType, NewMonsterType _newMonsterType)
    {
        foreach (var item in _newHouseType)
        {
            if(item == NewHouseType.COLOR_CAT && _newMonsterType == NewMonsterType.CAT)
                return true;

            if(item == NewHouseType.COLOR_FROG && _newMonsterType == NewMonsterType.FROG)
                return true;

            if(item == NewHouseType.COLOR_HAMSTER && _newMonsterType == NewMonsterType.HAMSTER)
                return true;

            if(item == NewHouseType.COLOR_LION && _newMonsterType == NewMonsterType.LION)
                return true;

            if(item == NewHouseType.COLOR_RABBIT && _newMonsterType == NewMonsterType.RABBIT)
                return true;

            if(item == NewHouseType.SHADOW_CAT && _newMonsterType == NewMonsterType.CAT)
                return true;

            if(item == NewHouseType.SHADOW_FROG && _newMonsterType == NewMonsterType.FROG)
                return true;

            if(item == NewHouseType.SHADOW_HAMSTER && _newMonsterType == NewMonsterType.HAMSTER)
                return true;

            if(item == NewHouseType.SHADOW_LION && _newMonsterType == NewMonsterType.LION)
                return true;

            if(item == NewHouseType.SHADOW_RABBIT && _newMonsterType == NewMonsterType.RABBIT)
                return true;
        }

        return false;
    }

    private NewHouseType GetRandomAnswerType(AnswerType answerType, NewHouseType excludeType = NewHouseType.NULL)
    {
        return NewHouseTypeSelector.GetRandomAnswerType(answerType, excludeType);
    }
    
    private NewHouseType GetRandomAnswerType(AnswerType answerType, NewHouseType excludeType1, NewHouseType excludeType2)
    {
        return NewHouseTypeSelector.GetRandomAnswerType(answerType, excludeType1, excludeType2);
    }

    private List<NewMonsterItem> GetNewMonsterItem(NewHouseType newHouseType, int answerValueCount)
    {
        List<NewMonsterItem> newMonsterItems = new();


        return newMonsterItems;
    }

    private NewMonsterType GetConvertNewMonsterType(NewHouseType newHouseType)
    {
        return newHouseType switch
        {
            NewHouseType.COLOR_CAT or NewHouseType.SHADOW_CAT => NewMonsterType.CAT,
            NewHouseType.COLOR_FROG or NewHouseType.SHADOW_FROG => NewMonsterType.FROG,
            NewHouseType.COLOR_HAMSTER or NewHouseType.SHADOW_HAMSTER => NewMonsterType.HAMSTER,
            NewHouseType.COLOR_LION or NewHouseType.SHADOW_LION => NewMonsterType.LION,
            NewHouseType.COLOR_RABBIT or NewHouseType.SHADOW_RABBIT => NewMonsterType.RABBIT,
            _ => NewMonsterType.BLANK,
        };
    }
}

public struct AnswerClass
{
    public int mainIndex;
    public List<AnswerLine> answerLines;
    public int answerValueCount;
}

public class AnswerLine
{
    public LineDirection lineDirection;
    public List<NewMonsterItem> newMonsterItems = new();
    public List<NewHouseType> newHouseTypes = new();
    public List<int> newHousePositions = new();
    public int answerCount;
}

public enum LineDirection
{
    LeftToRight,
    RightToLeft
}

public enum AnswerType
{
    COLOR,
    SHADOW
}
