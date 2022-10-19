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
        HandleMovement(agent.movementData.agentMovement);
        // MoveToCell();
    }

    // protected override void ExitState()
    // {
    // }

    public override void StateUpdate()
    {
        if((nextPosition - (Vector2)agent.transform.position).magnitude < 0.1f)
            NextPositionArrived();
    }

    // void MoveToCell()
    // {
    //     DOTween.Kill(agent.rb2d);


    //     nextPosition = GridUtils.CellPositionInDirection(agent.transform.position, movementDirection);

    //     Debug.Log($"RunState.MoveToCell.nextPosition: {nextPosition}");

    //     agent.rb2d
    //         .DOMove(nextPosition, agent.agentData.maxSpeed)
    //         .OnComplete(MovementFinished)
    //         .SetEase(Ease.Linear)
    //         .SetSpeedBased();
    // }

    void NextPositionArrived()
    {
        agent.rb2d.MovePosition(nextPosition);

        if(agent.wallInFrontSensor.HasHit() || inputDirection.magnitude == 0f)
            agent.stateManager.TransitionToState(StateType.Idle);
        else
            HandleMovement(agent.movementData.agentMovement);
    }

    // protected override void HandleAnimationAction()
    // {
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
        inputDirection = Vector2Utils.DirectionDiscrete(movement);

        if(inputDirection.magnitude == 0)
            return;

        if(agent.wallInAllDirectionsSensor.HasHitInDirection(inputDirection))
            return;

        Vector2 possibleNextPosition = GridUtils.CellPositionInDirection(agent.transform.position, inputDirection);
        if(
            possibleNextPosition != nextPosition &&
            Vector2Utils.AngleBetweenVectorsIs90DegreesMultiple(agent.transform.position, possibleNextPosition)
        )
        {
            ChangeNextPosition(possibleNextPosition);
            // MoveToCell();
        }
    }

    void ChangeNextPosition(Vector2 position)
    {
        // Debug.Log($"RunState.ChangeNextPosition: {position}");
        nextPosition = position;
        Vector2 direction = Vector2Utils.DirectionBetweenVectors(agent.transform.position, position).normalized;
        agent.rb2d.velocity = direction * agent.agentData.maxSpeed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(nextPosition, 0.1f);
    }
}
