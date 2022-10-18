using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpState : RunState
{
    bool jumpPressed = false;
    public UnityEvent OnJump;

    public override StateType Type()
    {
        return StateType.Jump;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.jump);
        agent.rb2d.AddForce(Vector2.up * agent.agentData.jumpForce, ForceMode2D.Impulse);
        jumpPressed = true;

        OnJump?.Invoke();
    }

    public override void StateFixedUpdate()
    {
        ApplyLowJumpModifier();

        if(agent.rb2d.velocity.y <= 0)
        {
            agent.rb2d.velocity = new Vector2(agent.rb2d.velocity.x, 0f);
            agent.stateManager.TransitionToState(StateType.Fall);
        }
    }

    void ApplyLowJumpModifier()
    {
        if(!jumpPressed)
            agent.rb2d.AddForce(Vector2.down * agent.agentData.lowJumpForce, ForceMode2D.Force);
    }

    protected override void HandleJumpReleased()
    {
        jumpPressed = false;
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }


}
