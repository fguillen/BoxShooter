using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class RunState : State
{
    [SerializeField] private UnityEvent OnStep;

    Vector2 movementDirection;

    public override StateType Type()
    {
        return StateType.Run;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.run);
        movementDirection = agent.movementData.movementDirectionDiscrete;
        MoveToCell();
    }

    protected override void ExitState()
    {
        DOTween.Kill(agent.transform);
    }

    void MoveToCell()
    {
        DOTween.Kill(agent.transform);

        Vector2 nextPosition = GridUtils.CellPositionInDirection(agent.transform.position, movementDirection);
        // Debug.Log($"MoveToCell({nextPosition})");
        agent.transform
            .DOMove(nextPosition, agent.agentData.maxSpeed)
            .OnComplete(MovementFinished)
            .SetEase(Ease.Linear)
            .SetSpeedBased();
            // .SetUpdate(UpdateType.Late);
    }

    void MovementFinished()
    {
        if(movementDirection.magnitude == 0f)
            agent.stateManager.TransitionToState(StateType.Idle);
        else
            NextCell();
    }

    // protected override void HandleAnimationAction()
    // {
    //     Debug.Log($"HandleAnimationAction()");
    //     OnStep?.Invoke();
    // }

    // protected override void HandleAttack()
    // {
    //     Debug.Log($"HandleAttack()");
    //     if(agent.weaponManager.CanAttack())
    //         agent.stateManager.TransitionToState(StateType.Attack);
    // }

    // protected override void HandleHitted(Vector2 point)
    // {
    //     Debug.Log($"HandleHitted()");
    //     agent.stateManager.TransitionToState(StateType.Hit);
    // }

    protected override void HandleMovement(Vector2 movement)
    {
        // if(movement.x == movementDirection.x || movement.y == movementDirection.y)
        // {

        // }

        movementDirection = agent.movementData.movementDirectionDiscrete;
        NextCell();
    }

    void NextCell()
    {
        if(movementDirection.magnitude > 0f)
            MoveToCell();
    }
}
