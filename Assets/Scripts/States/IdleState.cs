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

        if(agent.rb2d.bodyType != RigidbodyType2D.Static)
            if(agent.groundSensor == null || agent.groundSensor.IsGrounded())
                agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 movement)
    {
        if(Mathf.Abs(movement.x) > 0)
            agent.stateManager.TransitionToState(StateType.Run);
        else if(Mathf.Abs(movement.y) > 0 && agent.climbSensor.canClimb)
            agent.stateManager.TransitionToState(StateType.Climb);
    }

    protected override void HandleAttack()
    {
        if(agent.weaponManager.CanAttack())
            agent.stateManager.TransitionToState(StateType.Attack);
    }

    public override void StateFixedUpdate()
    {
        if(agent.groundSensor != null && !agent.groundSensor.IsGrounded())
            agent.stateManager.TransitionToState(StateType.Fall);
    }

    protected override void HandleJumpPressed()
    {
        if(agent.groundSensor == null || agent.groundSensor.IsGrounded())
            agent.stateManager.TransitionToState(StateType.Jump);
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
