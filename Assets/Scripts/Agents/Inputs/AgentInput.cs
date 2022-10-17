using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInput : MonoBehaviour
{
    // public Vector2 MovementVector { get; set; }
    public event Action OnAttack;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action OnWeaponChange;
    public event Action<Vector2> OnMovement;

    public void CallAttack()
    {
        OnAttack?.Invoke();
    }

    public void CallJumpPressed()
    {
        OnJumpPressed?.Invoke();
    }

    public void CallJumpReleased()
    {
        OnJumpReleased?.Invoke();
    }

    public void CallWeaponChange()
    {
        OnWeaponChange?.Invoke();
    }

    public void CallMovement(Vector2 vector)
    {
        OnMovement?.Invoke(vector);
    }
}
