using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewMonsterView : MonoBehaviour
{
    public const float jumpHeight = 0.2f; // 점프 높이
    public float jumpDuration = 0.4f; // 올수직 상승/하강 시간
    private Vector3 startPosition; // 시작 위치
    private float timer = 0.0f; // 경과 시간
    private float xPosition = 0.0f; // x축 위치
    private float xMiddlePosition = 0.0f; // x축 위치

    private bool isStart = false;

    private JumpState jumpState = JumpState.VerticalUp;
    private float parabolaDuration = 0.4f; // 포물선 시간
    public const float parabolaJumpHeight = 1.0f; // 점프 높이
    private float[] xPositions = new float[10]; // 등간격 포인트 (x 좌표)
    private int currentPointIndex = 0; // 현재 포인트 인덱스
    private float currentPointX = 0; // 현재 위치 x    

    private LineDirection lineDirection;

    private ObjectPool objectPool;

    [Header("Sprite")]
    public SpriteRenderer spriteRenderer_MAIN;

    [Header("Sprite")]
    public Sprite sprite_CAT;
    public Sprite sprite_FROG;
    public Sprite sprite_HAMSTER;
    public Sprite sprite_LION;
    public Sprite sprite_RABBIT;

    private NewMonsterType newMonsterType;
    private NewHouseType newHouseType;

    private GameObject houseObject;

    private int lineNumber;

    [Header("Test")]
    public TMP_Text test_TMP_Text;

    void Start()
    {
        // startPosition = transform.position; // 시작 위치 저장
        // xPosition = startPosition.x;
        
        // 등간격 포인트를 생성 (-12.45에서 12.45까지)
        float interval = (12.45f - (-12.45f)) / (xPositions.Length - 1);
        for (int i = 0; i < xPositions.Length; i++)
        {
            xPositions[i] = -12.45f + i * interval;
        }
    }

    public NewMonsterType GetNewMonsterType()
    {
        return newMonsterType;
    }

    public void TestIndex(int _index)
    {
        if(Debug.isDebugBuild)
            test_TMP_Text.text = _index.ToString();
        else
            test_TMP_Text.text = "";
    }

    public int GetLineNumber()
    {
        return lineNumber;
    }

    public void SetSprite(NewMonsterType _newMonsterType)
    {
        newMonsterType = _newMonsterType;
        spriteRenderer_MAIN.sprite = _newMonsterType switch
        {
            NewMonsterType.CAT => sprite_CAT,
            NewMonsterType.FROG => sprite_FROG,
            NewMonsterType.HAMSTER => sprite_HAMSTER,
            NewMonsterType.LION => sprite_LION,
            NewMonsterType.RABBIT => sprite_RABBIT,
            _ => null,
        };
    }

    public void SetObjectPool(ObjectPool _objectPool)
    {
        objectPool = _objectPool;
    }

    public void SetPosition(int _lineNumber, AnswerLine _answerLine)
    {
        OnEnableBoxCollider();
        SetSprite(NewMonsterType.BLANK);
        lineNumber = _lineNumber;
        if (_lineNumber == 1)
        {
            if (_answerLine.lineDirection == LineDirection.LeftToRight)
            {
                lineDirection = LineDirection.LeftToRight;
                gameObject.transform.localPosition = new Vector3(-12.45f, 0.64f, -2f);
                startPosition = gameObject.transform.localPosition;
                currentPointIndex = 0;
                xPosition = startPosition.x;
                SetSprite(newMonsterType);
                return;
            }

            if (_answerLine.lineDirection == LineDirection.RightToLeft)
            {
                lineDirection = LineDirection.RightToLeft;
                gameObject.transform.localPosition = new Vector3(12.45f, 0.64f, -2f);
                startPosition = gameObject.transform.localPosition;
                currentPointIndex = 9;
                xPosition = startPosition.x;
                SetSprite(newMonsterType);
                return;
            }
        }

        if (_lineNumber == 2)
        {
            if (_answerLine.lineDirection == LineDirection.LeftToRight)
            {
                lineDirection = LineDirection.LeftToRight;
                gameObject.transform.localPosition = new Vector3(-12.45f, 2.0f, -0.5f);
                startPosition = gameObject.transform.localPosition;
                currentPointIndex = 0;
                xPosition = startPosition.x;
                SetSprite(newMonsterType);
                return;
            }

            if (_answerLine.lineDirection == LineDirection.RightToLeft)
            {
                lineDirection = LineDirection.RightToLeft;
                gameObject.transform.localPosition = new Vector3(12.45f, 2.0f, -0.5f);
                startPosition = gameObject.transform.localPosition;
                currentPointIndex = 9;
                xPosition = startPosition.x;
                SetSprite(newMonsterType);
                return;
            }
        }

        if (_lineNumber == 3)
        {
            if (_answerLine.lineDirection == LineDirection.LeftToRight)
            {
                lineDirection = LineDirection.LeftToRight;
                gameObject.transform.localPosition = new Vector3(-12.45f, -0.67f, -2f);
                startPosition = gameObject.transform.localPosition;
                currentPointIndex = 0;
                xPosition = startPosition.x;
                SetSprite(newMonsterType);
                return;
            }

            if (_answerLine.lineDirection == LineDirection.RightToLeft)
            {
                lineDirection = LineDirection.RightToLeft;
                gameObject.transform.localPosition = new Vector3(12.45f, -0.67f, -2f);
                startPosition = gameObject.transform.localPosition;
                currentPointIndex = 9;
                xPosition = startPosition.x;
                SetSprite(newMonsterType);
                return;
            }
        }
    }

    public void EnableBoxCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnEnableBoxCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void StartMove()
    {
        jumpState = JumpState.VerticalUp;
        timer = 0.0f;
        isStart = true;
    }

    public void StopMove()
    {
        isStart = false;
    }

    private enum JumpState
    {
        VerticalUp,
        VerticalDown,
        ParabolaUp,
        ParabolaDown        
    }

    private void OnDisable()
    {
        isStart = false;
    }

    void FixedUpdate()
    {
        if (!isStart)
            return;

        timer += Time.fixedDeltaTime;
        float progress = 0;
        // float parabolaY = 0;
        float newX = 0;
        float newY = 0;

        switch (jumpState)
        {
            case JumpState.VerticalUp: // 수직 상승
                progress = timer / jumpDuration;
                if (progress >= 1.0f)
                {
                    progress = 1.0f;
                    timer = 0.0f; // 타이머 초기화
                    jumpState = JumpState.VerticalDown;
                }

                newY = Mathf.Lerp(startPosition.y, startPosition.y + jumpHeight, progress);
                transform.position = new Vector3(xPosition, newY, transform.position.z);
                
                break;

            case JumpState.VerticalDown: // 수직 하강
                progress = timer / jumpDuration;
                if (progress >= 1.0f)
                {
                    timer = 0.0f; // 타이머 초기화
                    jumpState = JumpState.ParabolaUp;
                    
                    currentPointX = xPositions[currentPointIndex];

                    if(lineDirection == LineDirection.LeftToRight)
                        currentPointIndex++;
                        
                    if(lineDirection == LineDirection.RightToLeft)
                        currentPointIndex--;
                    
                    xPosition = xPositions[currentPointIndex]; // 다음 포인트로 이동
                    
                    xMiddlePosition = (xPosition + currentPointX) * 0.5f;

                    newY = Mathf.Lerp(startPosition.y + jumpHeight, startPosition.y, 1.0f);
                    transform.position = new Vector3(currentPointX, newY, transform.position.z);                    
                    break;
                }
                newY = Mathf.Lerp(startPosition.y + jumpHeight, startPosition.y, progress);
                transform.position = new Vector3(xPosition, newY, transform.position.z);
                break;

            case JumpState.ParabolaUp: // 포물선 상승
                progress = timer / parabolaDuration;
                if (progress >= 1.0f)
                {
                    timer = 0.0f; // 타이머 초기화
                    jumpState = JumpState.ParabolaDown;
                    currentPointX = transform.position.x;

                    newX = Mathf.Lerp(currentPointX, xMiddlePosition, 1.0f);
                    newY = Mathf.Lerp(startPosition.y, startPosition.y + parabolaJumpHeight, 1.0f);
                    transform.position = new Vector3(newX, newY, transform.position.z);
                    break;
                }
                
                newX = Mathf.Lerp(currentPointX, xMiddlePosition, progress);
                newY = Mathf.Lerp(startPosition.y, startPosition.y + parabolaJumpHeight, progress);
                transform.position = new Vector3(newX, newY, transform.position.z);
                break;

            case JumpState.ParabolaDown: // 포물선 하강
                progress = timer / parabolaDuration;
                if (progress >= 1.0f)
                {
                    timer = 0.0f; // 타이머 초기화
                    jumpState = JumpState.VerticalUp; // 다시 수직 상승으로 전환

                    newX = Mathf.Lerp(currentPointX, xPosition, 1.0f);
                    newY = Mathf.Lerp(startPosition.y + parabolaJumpHeight, startPosition.y, 1.0f);
                    transform.position = new Vector3(newX, newY, transform.position.z);
                    break;
                }

                newX = Mathf.Lerp(currentPointX, xPosition, progress);
                newY = Mathf.Lerp(startPosition.y + parabolaJumpHeight, startPosition.y, progress);
                transform.position = new Vector3(newX, newY, transform.position.z);
                break;
        }

        // 이동 끝 조건
        if ((lineDirection == LineDirection.LeftToRight && transform.position.x >= 12.45f) ||
            (lineDirection == LineDirection.RightToLeft && transform.position.x <= -12.45f))
        {
            isStart = false;
            objectPool.SetPoolGameObject(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            newHouseType = other.gameObject.transform.parent.GetComponent<NewHouseItem>().GetNewHouseType();
            houseObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            newHouseType = NewHouseType.NULL;
            houseObject = null;
        }
    }

    public NewHouseType GetNewHouseType()
    {
        return newHouseType;
    }

    public GameObject GetHouseObject()
    {
        return houseObject;
    }
}