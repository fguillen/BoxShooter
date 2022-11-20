using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour, IHittable
{
    [SerializeField] BreakableData data;
    public UnityEvent OnHit;
    public UnityEvent OnOpened;

    int hitPoints;
    int numSprites;
    SpriteRenderer spriteRenderer;
    GameObject pickable;

    void Awake()
    {
        numSprites = data.sprites.Count;
        hitPoints = data.sprites.Count;
        spriteRenderer = transform.Find("Body").GetComponent<SpriteRenderer>();

        if(data.spriteColors.Count > 0)
            spriteRenderer.color = data.spriteColors[Random.Range(0, data.spriteColors.Count)];
    }

    void Start()
    {
        SetPickable();
        UpdateSprite();
    }

    public void GetHit(int damage, Vector2 point)
    {
        if(hitPoints == 0)
            return;

        hitPoints--;

        if(hitPoints == 0)
            Opened();
        else
        {
            UpdateSprite();
            OnHit?.Invoke();
        }
    }

    public Agent Agent()
    {
        return null;
    }

    void Opened()
    {
        spriteRenderer.enabled = false;
        OnOpened?.Invoke();
        DestroyObject();
    }

    void UpdateSprite()
    {
        int spriteIndex = numSprites - hitPoints;
        spriteRenderer.sprite = data.sprites[spriteIndex];
    }

    void DestroyObject()
    {
        if(pickable != null)
            pickable.GetComponent<Pickable>().isActive = true;

        Destroy(gameObject);
    }

    void SetPickable()
    {
        if(data.pickablePrefabs.Count > 0 && Utils.RandomChance(data.pickableChance))
        {
            GameObject pickablePrefab = Utils.RandomElement(data.pickablePrefabs);
            pickable = Instantiate(pickablePrefab, transform.position, Quaternion.identity);
            pickable.GetComponent<Pickable>().isActive = false;
        }
    }
}
