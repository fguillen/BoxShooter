using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpritesSortingOrderOnTop : MonoBehaviour
{
    void Awake()
    {
        SetSpritesOnTop(transform);
    }

    void SetSpritesOnTop(Transform transform)
    {
        List<SpriteRenderer> spriteRenders = transform.GetComponentsInChildren<SpriteRenderer>().ToList();
        foreach (var spriteRender in spriteRenders)
        {
            spriteRender.sortingOrder += (int)Time.time;
        }
    }
}
