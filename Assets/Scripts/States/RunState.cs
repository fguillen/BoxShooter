using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class RunState : State
{
    [SerializeField] private UnityEvent OnStep;

    Vector2 inputDirection;
    Vector2 movementDirection;
    Vector2 nextPosition;

    public override StateType Type()
    {
        return StateType.Run;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.run);
        HandleMovement(MovementUtils.DirectionDiscrete(agent.movementData.agentMovement));
        MoveToCell();
    }

    protected override void ExitState()
    {
        DOTween.Kill(agent.transform);
    }

    void MoveToCell()
    {
        DOTween.Kill(agent.transform);

        nextPosition = GridUtils.CellPositionInDirection(agent.transform.position, movementDirection);

        agent.transform
            .DOMove(nextPosition, agent.agentData.maxSpeed)
            .OnComplete(MovementFinished)
            .SetEase(Ease.Linear)
            .SetSpeedBased();
    }

    void MovementFinished()
    {
        if(inputDirection.magnitude == 0f)
            agent.stateManager.TransitionToState(StateType.Idle);
        else
        {
            movementDirection = inputDirection;
            MoveToCell();
        }
    }

    protected override void HandleAnimationAction()
    {
        OnStep?.Invoke();
    }

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
        inputDirection = MovementUtils.DirectionDiscrete(movement);
        Debug.Log($"RunState.HandelMovement({inputDirection})");

        if(
            inputDirection.magnitude > 0 &&
            ( movementDirection.x == inputDirection.x || movementDirection.y == inputDirection.y )
        )
        {
            Debug.Log("RunState.ChangingDirection");
            movementDirection = inputDirection;
            MoveToCell();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(nextPosition, 0.1f);
    }
}
