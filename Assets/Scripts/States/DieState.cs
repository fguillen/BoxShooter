using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieState : State
{
    public UnityEvent OnDie;
    public UnityEvent OnDestroy;
    [SerializeField] float waitUntilDestroySeconds = 2f;
    [SerializeField] Collider2D hitCollider;

    public override StateType Type()
    {
        return StateType.Die;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.die);

        agent.rb2d.velocity = Vector2.zero;

        OnDie?.Invoke();
        hitCollider.enabled = false;
    }

    protected override void HandleAnimationEnd()
    {
        Invoke("CallDestroy", waitUntilDestroySeconds);
    }

    void CallDestroy()
    {
        OnDestroy?.Invoke();
        hitCollider.enabled = true;
        agent.DestroyOrRespawn();
    }
}
