using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickable : MonoBehaviour
{
    public UnityEvent<Agent> OnPicked;

    Collider2D theCollider;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        theCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Pickable.OnTriggerEnter2D({other.tag}, {other.gameObject.name})");
        if(other.CompareTag("Player"))
            PickUp(other.GetComponent<Agent>());
    }

    void PickUp(Agent agent)
    {
        Debug.Log("Pickable.PickUp");
        OnPicked?.Invoke(agent);
        DestroyObject();
    }

    void DestroyObject()
    {
        theCollider.enabled = false;
        spriteRenderer.enabled = false;
        Destroy(gameObject, 1f);
    }
}
