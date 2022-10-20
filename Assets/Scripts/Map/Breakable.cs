using UnityEngine;

public class Breakable : MonoBehaviour, IHittable
{
    [SerializeField] BreakableData data;

    int hitPoints;
    int numSprites;
    SpriteRenderer spriteRendererBody;
    GameObject pickable;

    void Awake()
    {
        numSprites = data.sprites.Count;
        hitPoints = data.sprites.Count;
        spriteRendererBody = transform.Find("Body").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SetPickable();
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
        spriteRendererBody.sprite = data.sprites[spriteIndex];
    }

    void DestroyObject()
    {
        if(pickable != null)
            pickable.GetComponent<Pickable>().isActive = true;

        Destroy(gameObject);
    }

    void SetPickable()
    {
        if(data.pickablePrefab != null && Utils.RandomChance(data.pickableChance))
        {
            pickable = Instantiate(data.pickablePrefab, transform.position, Quaternion.identity);
            pickable.GetComponent<Pickable>().isActive = false;
        }
    }
}
