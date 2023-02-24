using System.Collections;
using UnityEngine;

public interface ICoroutinePlayer
{
    Coroutine StartRoutine(IEnumerator coroutine);
    void StopRoutine(Coroutine coroutine);
}