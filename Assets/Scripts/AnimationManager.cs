using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    AnimationType animationActive;
    public event Action OnAnimationAction;
    public event Action OnAnimationEnd;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType animationType)
    {
        if(animationActive == animationType) return;

        switch (animationType)
        {
            case AnimationType.idle:
                Play("Idle");
                break;

            case AnimationType.run:
                Play("Run");
                break;

            case AnimationType.jump:
                Play("Jump");
                break;

            case AnimationType.fall:
                Play("Fall");
                break;

            case AnimationType.climb:
                Play("Climb");
                break;

            case AnimationType.attack:
                Play("Attack");
                break;

            case AnimationType.hit:
                Play("Hit");
                break;

            case AnimationType.die:
                Play("Die");
                break;

            case AnimationType.fly:
                Play("Fly");
                break;

            default:
                break;
        }

        animationActive = animationType;
    }

    void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }

    void HandleAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }

    void HandleAnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}
