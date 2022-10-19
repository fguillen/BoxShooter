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
        // MoveToCell();
    }

    protected override void ExitState()
    {
        DOTween.Kill(agent.transform);
    }

    void MoveToCell()
    {
        DOTween.Kill(agent.transform);

        nextPosition = GridUtils.CellPositionInDirection(agent.transform.position, movementDirection);

        Debug.Log($"RunState.MoveToCell.nextPosition: {nextPosition}");

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

        if(inputDirection.magnitude == 0)
            return;

        Vector2 possibleNextPosition = GridUtils.CellPositionInDirection(agent.transform.position, inputDirection);
        if(Vector2Utils.AngleBetweenVectorsIs90DegreesMultiple(agent.transform.position, possibleNextPosition))
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
