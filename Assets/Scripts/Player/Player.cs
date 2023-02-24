using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string JumpAnimationTrigger = "Jump";

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private RagDollSwitcher _animatorSwitcher;

    public event Action OnPlayerHitWall;

    public void Jump()
    {
        _animator.SetTrigger(JumpAnimationTrigger);
    }

    public void OnHitWall()
    {
        OnPlayerHitWall();
    }

    public void OnDie()
    {
        _animatorSwitcher.EnableRagdoll();
    }
}
