using UnityEngine;

public class Breakable : MonoBehaviour, IHittable
{
    [SerializeField] BreakableData data;
    int hitPoints;
    int numSprites;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        numSprites = data.sprites.Count;
        hitPoints = data.sprites.Count;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        UpdateSprite();
    }

    public void GetHit(int damage, Vector2 point)
    {
        hitPoints--;

        if(hitPoints == 0)
            DestroyObject();
        else
            UpdateSprite();
    }

    public Agent Agent()
    {
        return null;
    }

    void UpdateSprite()
    {
        int spriteIndex = numSprites - hitPoints;
        spriteRenderer.sprite = data.sprites[spriteIndex];
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
