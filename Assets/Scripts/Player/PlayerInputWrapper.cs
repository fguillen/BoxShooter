using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputWrapper : AgentInput
{
    public void OnInputMove(InputValue value)
    {
        var direction = value.Get<Vector2>();
        CallMovement(direction);
    }

    public void OnInputAttack(InputValue value)
    {
        Debug.Log($"OnInputAttack({value.Get<float>()})");
        CallAttack();
    }

    public void OnInputJump(InputValue value)
    {
        Debug.Log($"OnInputAttack({value.Get<float>()})");
        if(value.Get<float>() == 1)
            CallJumpPressed();
        else
            CallJumpReleased();
    }
}
