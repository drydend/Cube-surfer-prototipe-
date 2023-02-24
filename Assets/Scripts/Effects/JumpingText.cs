using System.Collections;
using TMPro;
using UnityEngine;

public class JumpingText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private AnimationCurve _jumpCurve;
    [SerializeField]
    private bool _destronOnAnimationEnd;

    public void Initialize(Vector3 initialPosition, Vector3 targetPosition, string text)
    {
        _text.text = text;
        StartCoroutine(MovingRoutine(initialPosition, targetPosition));
    }

    private IEnumerator MovingRoutine(Vector3 initialPosition, Vector3 targetPosition)
    {
        transform.position = initialPosition;
        var timeElapseNormalized = 0f;

        while (timeElapseNormalized != 1)
        {
            var tValue = _jumpCurve.Evaluate(timeElapseNormalized);
            transform.position = Vector3.Lerp(initialPosition, targetPosition, tValue);

            timeElapseNormalized = Mathf.Clamp(timeElapseNormalized + Time.deltaTime / _lifeTime, 0, 1);
            yield return null;
        }

        transform.position = targetPosition;

        if (_destronOnAnimationEnd)
        {
            Destroy(gameObject);
        }
    }
}