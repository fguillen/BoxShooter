using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    Door door;
    Sequence sequence;
    Collider2D theCollider;

    void Awake()
    {
        door = FindObjectOfType<Door>();
        theCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        GoToDoor();
    }

    public void GoToDoor()
    {
        theCollider.enabled = false;

        if(sequence != null)
            sequence.Kill();

        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(door.transform.position.x, speed).SetSpeedBased());
        sequence.Append(transform.DOMoveY(door.transform.position.y, speed).SetSpeedBased());
        sequence.OnComplete(OpenDoor);
    }

    void OpenDoor()
    {
        Debug.Log("Key.OpenDoor()");
        if(sequence != null)
            sequence.Kill();

        door.GetKey();
        Destroy(gameObject);
    }
}
