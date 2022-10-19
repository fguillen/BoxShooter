using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override StateType Type()
    {
        return StateType.Idle;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.idle);
        agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.magnitude) > 0f)
            agent.stateManager.TransitionToState(StateType.Run);
    }

    protected override void HandleAttack()
    {
        if(agent.weaponManager.CanAttack())
            agent.stateManager.TransitionToState(StateType.Attack);
    }

    protected override void HandleJumpPressed()
    {
        agent.stateManager.TransitionToState(StateType.Jump);
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
