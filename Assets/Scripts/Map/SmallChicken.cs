using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SmallChicken : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    Animator animator;
    House house;
    Sequence sequence;
    Collider2D theCollider;
    bool goingHome = false;
    SpiralMovement spiralMovement;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        house = FindObjectOfType<House>();
        theCollider = GetComponent<Collider2D>();
        spiralMovement = this.GetComponentThrowIfNotFound<SpiralMovement>();
    }

    void Start()
    {
        animator.Play("Idle", -1, 0f);
    }

    public void GoToHouse()
    {
        Debug.Log("SmallChicken.GoToHouse()");
        goingHome = true;

        animator.Play("Fly", -1, 0f);

        spiralMovement.enabled = true;
        spiralMovement.destiny = house.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"SmallChicken.OnTriggerEnter2D({other.tag})");
        if(other.CompareTag("Door"))
            OpenHouse();
    }

    void OpenHouse()
    {
        Debug.Log("SmallChicken.OpenHouse()");
        if(sequence != null)
            sequence.Kill();

        house.GetKey();
        Destroy(gameObject);
    }
}
