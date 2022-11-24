using System.Collections.Generic;
using UnityEngine;

public struct SpriteRendererOriginalStruct
{
    public SpriteRenderer spriteRenderer { get; }
    public Material originalMaterial { get; }
    public Color originalColor { get; }

    public SpriteRendererOriginalStruct(SpriteRenderer spriteRenderer)
    {
        this.originalMaterial = spriteRenderer.material;
        this.originalColor = spriteRenderer.color;
        this.spriteRenderer = spriteRenderer;
    }

    public static List<SpriteRendererOriginalStruct> BuildSpriteRendererOriginalsCollection(List<SpriteRenderer> spriteRenderers)
    {
        List<SpriteRendererOriginalStruct> result = new List<SpriteRendererOriginalStruct>();

        foreach (var spriteRenderer in spriteRenderers)
        {
            var spriteRendererOriginal = new SpriteRendererOriginalStruct(spriteRenderer);
            result.Add(spriteRendererOriginal);
        }

        return result;
    }

    public static void SetOriginalMaterial(List<SpriteRendererOriginalStruct> elements)
    {
        foreach (var spriteRendererOriginal in elements)
            spriteRendererOriginal.spriteRenderer.material = spriteRendererOriginal.originalMaterial;
    }

    public static void SetOriginalColor(List<SpriteRendererOriginalStruct> elements)
    {
        foreach (var spriteRendererOriginal in elements)
            spriteRendererOriginal.spriteRenderer.color = spriteRendererOriginal.originalColor;
    }
}
