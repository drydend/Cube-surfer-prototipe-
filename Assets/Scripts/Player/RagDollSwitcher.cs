using System.Collections.Generic;
using UnityEngine;

public class RagDollSwitcher : MonoBehaviour
{
    [SerializeField]
    private List<Rigidbody> _ragdollRigidbodies;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody _defaultRigidbody;

    private void Awake()
    {
        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        _animator.enabled = false;
        _defaultRigidbody.isKinematic = true;

        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    public void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }

        _defaultRigidbody.isKinematic = false;
        _animator.enabled = true;
    }
}