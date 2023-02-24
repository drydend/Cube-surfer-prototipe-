using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private float _fadeDuration;
    [SerializeField]
    private float _unfadeDuration;
    [SerializeField]
    private bool _unfadeOnAwake;

    private Coroutine _fadeCoroutine;

    public void FadeScreen(Action callback = null)
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _fadeCoroutine = StartCoroutine(FadeAnimation(callback));
    }
    public void UnfadeScreen()
    {
        if(_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _fadeCoroutine = StartCoroutine(UnfadeAnimation());
    }


    private IEnumerator FadeAnimation(Action callback)
    {
        _image.enabled = true;
        var animationTimeNormalized = _image.color.a;
        
        while (animationTimeNormalized != 1)
        {
            var color = new Color(_image.color.r, _image.color.g, _image.color.b, animationTimeNormalized);
            _image.color = color;

            animationTimeNormalized = Mathf.Clamp(animationTimeNormalized + Time.deltaTime / _fadeDuration, 0,1);
            yield return null;
        }

        callback?.Invoke();
    }

    private IEnumerator UnfadeAnimation()
    {
        var animationTimeNormalized = _image.color.a;

        while (animationTimeNormalized != 0)
        {
            var color = new Color(_image.color.r, _image.color.g, _image.color.b, animationTimeNormalized);
            _image.color = color;

            animationTimeNormalized = Mathf.Clamp(animationTimeNormalized - Time.deltaTime / _unfadeDuration, 0, 1);
            yield return null;
        }

        _image.enabled = false;
    }

    private void Awake()
    {
        if (_unfadeOnAwake)
        {
            UnfadeScreen();
        }
    }
}
