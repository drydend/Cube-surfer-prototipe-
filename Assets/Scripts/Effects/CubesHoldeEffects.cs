using UnityEngine;

public class CubesHoldeEffects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _addCubeParticlePrefab;

    [Space]
    [SerializeField]
    private JumpingText _jumpingTextPrefab;
    [SerializeField]
    private float _textDistanceFromCube = 1f;
    [SerializeField]
    private float _textTargetPositionHeight = 1f;

    [Space]
    [SerializeField]
    private CameraShaker _cameraShaker;
    [SerializeField]
    private float _shakeDuration;
    [SerializeField]
    private float _shakeAmplitude;

    public void PlayCubeAddedEffects(StackableCube cube)
    {
        Instantiate(_addCubeParticlePrefab, cube.transform);

        var textInitialPosition = cube.transform.position + Random.insideUnitSphere * _textDistanceFromCube;
        textInitialPosition.y = Mathf.Abs(textInitialPosition.y);
        var textTargetPosition = textInitialPosition;
        var rotation = Quaternion.Euler(0, 0, 0);
        textTargetPosition.y = _textTargetPositionHeight;

        var textInstance = Instantiate(_jumpingTextPrefab, textInitialPosition, rotation);
        textInstance.Initialize(textInitialPosition, textTargetPosition, "+1");
    }

    public void PlayerCubeRemovedEffect()
    {
        _cameraShaker.ShakeCameraRotation(_shakeDuration, _shakeAmplitude);
    }
}