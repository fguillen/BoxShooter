using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public abstract StateType Type();

    public void Initialize(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        this.agent.agentInput.OnWeaponChange += HandleWeaponChange;
        this.agent.agentInput.OnMovement += HandleMovement;

        this.agent.damageManager.OnHit.AddListener(HandleHitted);
        this.agent.damageManager.OnDie.AddListener(HandleDie);

        this.agent.animationManager.OnAnimationAction += HandleAnimationAction;
        this.agent.animationManager.OnAnimationEnd += HandleAnimationEnd;

        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnWeaponChange -= HandleWeaponChange;
        this.agent.agentInput.OnMovement -= HandleMovement;

        this.agent.damageManager.OnHit.RemoveListener(HandleHitted);
        this.agent.damageManager.OnDie.RemoveListener(HandleDie);

        this.agent.animationManager.OnAnimationAction -= HandleAnimationAction;
        this.agent.animationManager.OnAnimationEnd -= HandleAnimationEnd;

        ExitState();
    }

    protected virtual void EnterState() {}
    protected virtual void ExitState() {}

    protected virtual void HandleMovement(Vector2 movement) {}
    protected virtual void HandleAttack() {}
    protected virtual void HandleJumpPressed() {}
    protected virtual void HandleJumpReleased() {}
    protected virtual void HandleWeaponChange() {}

    protected virtual void HandleHitted(Vector2 point) {}
    protected virtual void HandleDie() {}

    protected virtual void HandleAnimationAction() {}
    protected virtual void HandleAnimationEnd() {}

    public virtual void StateUpdate() {}
    public virtual void StateFixedUpdate() {}
}
