using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    [SerializeField] CanvasGroup _fadeGroup;

    Coroutine fadeCoroutine;



    public void GoToBlack(Action callback)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(Black(0.5f, callback));

        _fadeGroup.blocksRaycasts = true;
    }

    public void GoTransparent(Action callback)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(Transparent(0.5f, callback));

        _fadeGroup.blocksRaycasts = false;
    }

    IEnumerator Transparent(float speed, Action callback)
    {
        _fadeGroup.alpha = 1;

        while (_fadeGroup.alpha > 0)
        {
            _fadeGroup.alpha -= speed * Time.deltaTime;
            yield return null;
        }

        _fadeGroup.alpha = 0;

        if (callback != null)
        {
            callback.Invoke();
        }
    }

    IEnumerator Black(float speed, Action callback)
    {
        while (_fadeGroup.alpha < 1)
        {
            _fadeGroup.alpha += speed * Time.deltaTime;
            yield return null;
        }

        _fadeGroup.alpha = 1;

        if (callback != null)
        {
            callback.Invoke();
        }
    }
}
