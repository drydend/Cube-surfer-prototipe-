using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePlayer : MonoBehaviour, ICoroutinePlayer
{
    public void StopRoutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }

    public Coroutine StartRoutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }
}