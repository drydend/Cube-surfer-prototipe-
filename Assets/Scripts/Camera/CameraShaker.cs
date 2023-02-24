using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraHolder;

    private Coroutine _shakeCoroutine;
    private Quaternion _initialRotation;

    public void ShakeCameraRotation(float duration, float amplitude)
    {
        if(_shakeCoroutine!= null)
        {
            StopCoroutine(_shakeCoroutine);
            _cameraHolder.rotation = _initialRotation;
        }

        _shakeCoroutine = StartCoroutine(ShakeCameraRotationRoutine(duration, amplitude));
    }

    private IEnumerator ShakeCameraRotationRoutine(float duration, float amplitude)
    {
        var timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            var x = Random.Range(- amplitude, amplitude);
            var y = Random.Range(- amplitude, amplitude);
            var z = Random.Range(- amplitude, amplitude);

            var rotation = Quaternion.Euler(x, y, z);
            _cameraHolder.rotation = rotation;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _cameraHolder.rotation = _initialRotation;
    }

    private void Awake()
    {
        _initialRotation = transform.rotation;
    }
}