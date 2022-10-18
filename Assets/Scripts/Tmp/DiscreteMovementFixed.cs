using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class DiscreteMovementFixed : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    // Vector2 movementDirection;

    Vector2 nextPosition;

    void Start()
    {
        // Move();
        nextPosition = new Vector2(10f, transform.position.y);
    }

    // void Move()
    // {
    //     // DOTween.Kill(transform);

    //     // Vector2 nextPosition = GridUtils.CellPositionInDirection(transform.position, movementDirection);
    //     // Vector2 nextPosition = new Vector2(10f, 0f);

    //     transform
    //         .DOMove(nextPosition, speed)
    //         // .OnComplete(NextCell)
    //         .SetEase(Ease.Linear)
    //         .SetSpeedBased()
    //         // .SetUpdate(UpdateType.Fixed);
    //         ;
    // }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, nextPosition, step);
    }

    // void NextCell()
    // {
    //     if(movementDirection.magnitude > 0f)
    //         MoveToCell(movementDirection);
    // }

    // public void HandleMovement(Vector2 movement)
    // {
    //     movementDirection = movement;
    //     NextCell();
    // }
}
