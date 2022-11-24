using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittedState : State
{
    public UnityEvent OnHit;

    public override StateType Type()
    {
        return StateType.Hit;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.hit);
        OnHit?.Invoke();
    }

    protected override void HandleAnimationEnd()
    {
        agent.stateManager.TransitionToState(StateType.Idle);
    }
}
