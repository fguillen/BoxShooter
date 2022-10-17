using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : AgentInput
{
    public KeyCode jumpKey, attackKey, menuKey;
    public UnityEvent OnMenuKeyPressed;

    void Update()
    {
        if(Time.timeScale > 0)
        {
            GetWeaponChangeInput();
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
        }

        GetMenuInput();
    }

    void GetWeaponChangeInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            CallWeaponChange();
    }

    void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
            CallJumpPressed();

        if (Input.GetKeyUp(jumpKey))
            CallJumpReleased();
    }

    void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
            CallAttack();
    }

    void GetMenuInput()
    {
        if (Input.GetKeyDown(menuKey))
            OnMenuKeyPressed?.Invoke();
    }

    void GetMovementInput()
    {
        Vector2 direction = GetMovementVector();
        CallMovement(direction);
    }

    protected Vector2 GetMovementVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
