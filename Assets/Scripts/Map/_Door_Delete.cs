using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorDelete : MonoBehaviour
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

        spriteRenderer = transform.FindRecursive("Door").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        UpdateSprite();
    }

    public void GetKey()
    {
        Debug.Log("House.GetKey()");

        if(numKeysMissing == 0)
            return;

        numKeysMissing--;
        Debug.Log($"House.numKeysMissing: {numKeysMissing}");

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
        Debug.Log("House.DoorOpen()");
        isOpen = true;
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
