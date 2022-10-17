using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallState : RunState
{
    public UnityEvent OnLand;

    public override StateType Type()
    {
        return StateType.Fall;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.fall);
    }

    protected override void ExitState()
    {
        if(agent.groundSensor.IsGrounded())
            OnLand?.Invoke();
    }


    public override void StateUpdate()
    {
        if(agent.climbSensor != null && agent.climbSensor.canClimb && agent.movementData.movementLastDirection.y > 0)
            agent.stateManager.TransitionToState(StateType.Climb);
    }

    public override void StateFixedUpdate()
    {
        ApplyFallForce();
        SetPlayerVelocity();

        if(agent.groundSensor.IsGrounded())
            agent.stateManager.TransitionToState(StateType.Idle);
    }

    void ApplyFallForce()
    {
        agent.rb2d.AddForce(Vector2.down * agent.agentData.fallForce, ForceMode2D.Force);
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
