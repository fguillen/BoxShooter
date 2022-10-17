using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunState : State
{
    [SerializeField] private UnityEvent OnStep;

    public override StateType Type()
    {
        return StateType.Run;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.run);

        if(agent.rb2d.bodyType != RigidbodyType2D.Static)
            agent.rb2d.velocity = Vector2.zero;

        agent.movementData.currentSpeed = 0f;
        agent.movementData.currentVelocity = Vector2.zero;
    }

    public override void StateFixedUpdate()
    {
        if(agent.groundSensor != null && !agent.groundSensor.IsGrounded())
        {
            agent.stateManager.TransitionToState(StateType.Fall);
            return;
        }

        SetPlayerVelocity();

        if(Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
            agent.stateManager.TransitionToState(StateType.Idle);
    }

    protected void SetPlayerVelocity()
    {
        CalculateSpeed();
        CalculateVelocity();

        if(agent.rb2d.bodyType != RigidbodyType2D.Static)
            agent.rb2d.velocity = agent.movementData.currentVelocity;
    }

    void CalculateSpeed()
    {
        if(Mathf.Abs(agent.movementData.agentMovement.x) > 0f)
            agent.movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        else
            agent.movementData.currentSpeed -= agent.agentData.deceleration * Time.deltaTime;

        agent.movementData.currentSpeed = Mathf.Clamp(agent.movementData.currentSpeed, 0f, agent.agentData.maxSpeed);
    }

    void CalculateVelocity()
    {
        agent.movementData.currentVelocity = new Vector2(agent.movementData.movementLastDirection.x * agent.movementData.currentSpeed, agent.rb2d.velocity.y);
    }

    protected override void HandleJumpPressed()
    {
        if(agent.groundSensor == null || agent.groundSensor.IsGrounded())
            agent.stateManager.TransitionToState(StateType.Jump);
    }

    protected override void HandleAnimationAction()
    {
        OnStep?.Invoke();
    }

    protected override void HandleAttack()
    {
        if(agent.weaponManager.CanAttack())
            agent.stateManager.TransitionToState(StateType.Attack);
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
