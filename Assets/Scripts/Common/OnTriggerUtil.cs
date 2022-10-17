using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerUtil : MonoBehaviour
{
    public UnityEvent<Collider2D> OnEnter;
    public UnityEvent<Collider2D> OnExit;

    void OnTriggerEnter2D(Collider2D collider)
    {
        OnEnter?.Invoke(collider);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        OnExit?.Invoke(collider);
    }
}
