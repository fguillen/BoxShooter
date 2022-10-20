using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] public UnityEvent OnPlayerInDoor;

    SpriteRenderer spriteRenderer;
    int numKeysMissing;
    int numSprites;
    bool isOpen = false;

    void Awake()
    {
        numSprites = sprites.Count;
        numKeysMissing = sprites.Count - 1;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        UpdateSprite();
    }

    public void GetKey()
    {
        Debug.Log("Door.GetKey()");

        if(numKeysMissing == 0)
            return;

        numKeysMissing--;
        UpdateSprite();

        if(numKeysMissing == 0)
            DoorOpen();
    }

    void UpdateSprite()
    {
        int spriteIndex = numSprites - (numKeysMissing + 1);
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    void DoorOpen()
    {
        isOpen = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Door.OnTriggerEnter2D({other.tag}, {other.gameObject.name})");
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
