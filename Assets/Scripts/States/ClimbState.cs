using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : State
{
    float previousGravityScale;

    public override StateType Type()
    {
        return StateType.Climb;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.climb);

        agent.movementData.currentSpeed = 0f;
        agent.movementData.currentVelocity = Vector2.zero;

        previousGravityScale = agent.rb2d.gravityScale;
        agent.rb2d.gravityScale = 0f;
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = previousGravityScale;
    }

    public override void StateFixedUpdate()
    {
        if(!agent.climbSensor.canClimb)
        {
            agent.stateManager.TransitionToState(StateType.Idle);
            return;
        }

        SetPlayerVelocity();
    }

    protected void SetPlayerVelocity()
    {
        CalculateVelocity();

        agent.rb2d.velocity = agent.movementData.currentVelocity;
    }

    void CalculateVelocity()
    {
        agent.movementData.currentVelocity = agent.movementData.movementLastDirection * agent.agentData.climbSpeed;
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
