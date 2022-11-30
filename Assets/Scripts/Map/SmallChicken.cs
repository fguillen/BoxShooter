using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SmallChicken : MonoBehaviour
{
    Animator animator;
    Door door;
    Sequence sequence;
    Collider2D theCollider;
    bool goingHome = false;
    SpiralMovement spiralMovement;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        door = FindObjectOfType<Door>();
        theCollider = GetComponent<Collider2D>();
        spiralMovement = this.GetComponentThrowIfNotFound<SpiralMovement>();
    }

    void Start()
    {
        animator.Play("Idle", -1, 0f);
    }

    public void GoToDoor()
    {
        Debug.Log("SmallChicken.GoToDoor()");

        if(goingHome)
            return;

        goingHome = true;

        animator.Play("Fly", -1, 0f);

        spiralMovement.enabled = true;
        spiralMovement.destiny = door.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"SmallChicken.OnTriggerEnter2D({other.tag})");
        if(other.CompareTag("Door"))
            OpenDoor();
    }

    void OpenDoor()
    {
        Debug.Log("SmallChicken.OpenDoor()");
        if(sequence != null)
            sequence.Kill();

        door.GetKey();
        Destroy(gameObject);
    }
}
