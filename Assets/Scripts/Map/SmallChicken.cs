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

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        house = FindObjectOfType<House>();
        theCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        animator.Play("Idle", -1, 0f);
    }

    public void GoToHouse()
    {
        Debug.Log("SmallChicken.GoToHouse()");

        animator.Play("Fly", -1, 0f);
        theCollider.enabled = false;

        if(sequence != null)
            sequence.Kill();

        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(house.transform.position.x, speed).SetSpeedBased());
        sequence.Append(transform.DOMoveY(house.transform.position.y, speed).SetSpeedBased());
        sequence.OnComplete(OpenHouse);
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
