using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    public UnityEvent OnAttack;

    public override StateType Type()
    {
        return StateType.Attack;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.attack);
        agent.weaponManager.ToggleWeaponVisibility(true);

        agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleAnimationAction()
    {
        agent.weaponManager.Attack();
        OnAttack?.Invoke();
    }

    protected override void HandleAnimationEnd()
    {
        agent.weaponManager.ToggleWeaponVisibility(false);

        if(agent.movementData.IsMoving())
            agent.stateManager.TransitionToState(StateType.Run);
        else
            agent.stateManager.TransitionToPreviousState();
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }
}
