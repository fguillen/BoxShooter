using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyState : State
{
    [SerializeField] private UnityEvent OnStep;
    float originalGravityScale;

    public override StateType Type()
    {
        return StateType.Fly;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.fly);

        if(agent.rb2d.bodyType != RigidbodyType2D.Static)
        {
            agent.rb2d.velocity = Vector2.zero;
            originalGravityScale = agent.rb2d.gravityScale;
            agent.rb2d.gravityScale = 0f;
        }

        agent.movementData.currentSpeed = 0f;
        agent.movementData.currentVelocity = Vector2.zero;
    }

    protected override void ExitState()
    {
        agent.rb2d.gravityScale = originalGravityScale;
    }

    public override void StateFixedUpdate()
    {
        SetPlayerVelocity();
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
        if(agent.movementData.IsMoving())
            agent.movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        else
            agent.movementData.currentSpeed -= agent.agentData.deceleration * Time.deltaTime;

        agent.movementData.currentSpeed = Mathf.Clamp(agent.movementData.currentSpeed, 0f, agent.agentData.maxSpeed);
    }

    void CalculateVelocity()
    {
        agent.movementData.currentVelocity = agent.movementData.movementDirectionNormalized * agent.movementData.currentSpeed;
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
