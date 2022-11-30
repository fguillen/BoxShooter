using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] public UnityEvent OnPlayerInDoor;
    [SerializeField] int numKeys;
    [SerializeField] float rotationTime = 1f;
    [SerializeField] float rotationDelayTime = 0.2f;
    List<Transform> rotableSpirals;

    int numKeysMissing;
    bool isOpen = false;
    Coroutine rotationCoroutine;

    void Awake()
    {
        numKeysMissing = numKeys;
        rotableSpirals = transform.Find("Body/Spiral").GetChildren();
    }

    // void Start()
    // {
    //     DoorOpen();
    // }

    [ContextMenu("GetKey()")]
    public void GetKey()
    {
        Debug.Log("House.GetKey()");

        if(numKeysMissing == 0)
            return;

        numKeysMissing--;
        Debug.Log($"House.numKeysMissing: {numKeysMissing}");

        if(numKeysMissing == 0)
            DoorOpen();
        else
            RotateSpirals(false);
    }

    void DoorOpen()
    {
        Debug.Log("House.DoorOpen()");

        if(isOpen)
            return;

        isOpen = true;
        RotateSpirals(true);
    }

    void RotateSpirals(bool infinite)
    {
        if(rotationCoroutine != null)
            StopCoroutine(rotationCoroutine);

        rotationCoroutine = StartCoroutine(RotateSpiralsCoroutine(infinite));
    }

    IEnumerator RotateSpiralsCoroutine(bool infinite)
    {
        Debug.Log("RotateSpiralsCoroutine()");

        foreach (var spiral in rotableSpirals)
        {
            spiral.DOKill();
            DOTweenUtils.Rotate360(spiral, rotationTime, DOTweenUtils.DirectionType.ClockWise, infinite);
            yield return new WaitForSeconds(rotationDelayTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"House.OnTriggerEnter2D({other.tag}, {other.gameObject.name})");
        if(isOpen && other.CompareTag("Player"))
            PlayerInDoor(other.GetComponent<Agent>());
    }

    void PlayerInDoor(Agent agent)
    {
        Debug.Log("PlayerInDoor");
        OnPlayerInDoor?.Invoke();

        agent.DestroyObject();
    }
}
