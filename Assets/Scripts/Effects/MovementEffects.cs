using UnityEngine;

public class MovementEffects : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _warpEffect;

    public void PlayMovementEffects()
    {
        _warpEffect.Play();
    }

    public void StopPlayingMovementEffects()
    {
        _warpEffect.Stop();
    }
}