using System;
using System.Collections;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public void SetObjectMaterialAlphaZero(GameObject obj)
    {
        Color color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        obj.GetComponent<MeshRenderer>().material.color = color; 
    }

    public void SetMaterialAlphaZero(Material material)
    {
        Color color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        material.color = color;
    }

    public void SetObjectMaterialAlphaOne(GameObject obj)
    {
        Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        obj.GetComponent<MeshRenderer>().material.color = color; 
    }

    // Fade in 함수
    public void FadeInMaterial(GameObject obj)
    {
        StartCoroutine(Fade(obj.GetComponent<MeshRenderer>().material, 0f, 1f, 0.5f, 0.05f));
    }

    public void FadeInMaterial(Material _material)
    {
        StartCoroutine(Fade(_material, 0f, 1f, 0.5f, 0.05f));
    }

    // Fade out 함수
    public void FadeOutMaterial(GameObject obj)
    {
        StartCoroutine(Fade(obj.GetComponent<MeshRenderer>().material, 1f, 0f, 0.5f, 0.05f));
    }

    public void FadeOutMaterial(Material _material)
    {
        StartCoroutine(Fade(_material, 1f, 0f, 0.5f, 0.05f));
    }

    // 실제로 alpha 값을 변경하는 Coroutine 함수
    IEnumerator Fade(Material material, float startAlpha, float targetAlpha, float duration, float step)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            Color color = material.color;
            color.a = alpha;
            material.color = color;

            currentTime += step;
            yield return new WaitForSeconds(step);
        }

        // 마지막에 정확한 값을 설정해줌으로써 부정확한 값이 발생하지 않도록 보장
        Color finalColor = material.color;
        finalColor.a = targetAlpha;
        material.color = finalColor;
    }

    public void FadeInSpriteRenderer(GameObject obj)
    {
        StartCoroutine(Fade(obj.GetComponent<SpriteRenderer>(), 0.5f, 1, 0.5f, 0.05f));
    }

    // Fade out 함수
    public void FadeOutSpriteRenderer(GameObject obj, Action _action = null)
    {
        StartCoroutine(Fade(obj.GetComponent<SpriteRenderer>(), 1f, 0f, 0.5f, 0.05f, _action));
    }

    IEnumerator Fade(SpriteRenderer spriteRenderer, float startAlpha, float targetAlpha, float duration, float step, Action _action = null)
    {
        yield return new WaitForSeconds(0.5f);
        
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;

            currentTime += step;
            yield return new WaitForSeconds(step);
        }

        // 마지막에 정확한 값을 설정해줌으로써 부정확한 값이 발생하지 않도록 보장
        Color finalColor = spriteRenderer.color;
        finalColor.a = targetAlpha;
        spriteRenderer.color = finalColor;

        _action?.Invoke();
    }

    IEnumerator FadeAnswer(SpriteRenderer spriteRenderer, float startAlpha, float targetAlpha, float duration, float step)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;

            currentTime += step;
            yield return new WaitForSeconds(step);
        }

        // 마지막에 정확한 값을 설정해줌으로써 부정확한 값이 발생하지 않도록 보장
        Color finalColor = spriteRenderer.color;
        finalColor.a = targetAlpha;
        spriteRenderer.color = finalColor;
    }
}
