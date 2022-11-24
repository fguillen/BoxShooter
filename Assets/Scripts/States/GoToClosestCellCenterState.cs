using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoToClosestCellCenterState : State
{
    public override StateType Type()
    {
        return StateType.GoToClosestCellCenter;
    }

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.run);
        Vector2 destinyPosition = GridUtils.CellPositionByPosition(agent.transform.position);
        GoToDestinyPosition(destinyPosition);
    }

    protected override void HandleHitted(Vector2 point)
    {
        agent.stateManager.TransitionToState(StateType.Hit);
    }

    void GoToDestinyPosition(Vector2 destinyPosition)
    {
        agent.rb2d.DOMove(destinyPosition, 1f).SetSpeedBased().OnComplete(DestinyPositionArrived);
    }

    void DestinyPositionArrived()
    {
        agent.stateManager.TransitionToState(StateType.Idle);
    }
}
