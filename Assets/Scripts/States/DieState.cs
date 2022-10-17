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

        if(agent.rb2d.bodyType != RigidbodyType2D.Static)
            agent.rb2d.velocity = new Vector2(0f, agent.rb2d.velocity.y);

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
