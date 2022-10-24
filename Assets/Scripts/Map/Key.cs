using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    House house;
    Sequence sequence;
    Collider2D theCollider;

    void Awake()
    {
        house = FindObjectOfType<House>();
        theCollider = GetComponent<Collider2D>();
    }

    // void Start()
    // {
    //     GoToHouse();
    // }

    public void GoToHouse()
    {
        Debug.Log("Key.GoToHouse()");

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
        Debug.Log("Key.OpenHouse()");
        if(sequence != null)
            sequence.Kill();

        house.GetKey();
        Destroy(gameObject);
    }
}
