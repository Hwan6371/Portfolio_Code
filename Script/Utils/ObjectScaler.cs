using System;
using System.Collections;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private float totalDuration = 0.5f; // 전체 애니메이션 지속 시간

    public Vector3 setScale;
    private Vector3 initialScale;
    private Vector3 targetScale;

    private void Start()
    {

    }

    public void SetScaleZero()
    {
        transform.localScale = initialScale;
    }

    public void StartScaling()
    {
        initialScale = new Vector3(0f, 0f, 0f);
        targetScale = setScale; //new Vector3(1.0f, 1.0f, 1.0f);
        StartCoroutine(ScaleOverTime());
    }

    public void CloseScaling(Action _action = null)
    {
        initialScale = setScale;
        targetScale = new Vector3(0f, 0f, 0f);
        StartCoroutine(ScaleOverTime(_action));
    }

    private IEnumerator ScaleOverTime(Action _action = null)
    {
        float timer = 0f;

        while (timer < totalDuration)
        {
            float progress = timer / totalDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        _action?.Invoke();

       
    }
}