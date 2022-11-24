using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackWhiteFlash : MonoBehaviour, IFeedback
{
    [SerializeField] List<SpriteRenderer> spriteRenderers;
    [SerializeField] List<SpriteRendererOriginalStruct> spriteRendererOriginals = new List<SpriteRendererOriginalStruct>();
    [SerializeField] float durationSeconds = 0.1f;
    [SerializeField] Material solidColorMaterial;

    void Awake()
    {
        spriteRendererOriginals = SpriteRendererOriginalStruct.BuildSpriteRendererOriginalsCollection(spriteRenderers);

        if(solidColorMaterial == null || !solidColorMaterial.HasProperty("Active"))
            throw new Exception("Material not found or has no 'Active' property");
    }

    public void Perform()
    {
        Debug.Log("FeedbackWhiteFlash.Perform()");
        StopAllCoroutines();
        ToggleActive(true);
        StartCoroutine(ToggleDeactivateCoroutine());
    }

    void ToggleActive(bool val)
    {
        if(val)
        {
            SetMaterialInSpriteRenderers(solidColorMaterial);
            solidColorMaterial.SetFloat("Active", 1f);
        } else
        {
            SpriteRendererOriginalStruct.SetOriginalMaterial(spriteRendererOriginals);
            solidColorMaterial.SetFloat("Active", 0f);
        }
    }

    IEnumerator ToggleDeactivateCoroutine()
    {
        yield return new WaitForSeconds(durationSeconds);
        ToggleActive(false);
    }

    void SetMaterialInSpriteRenderers(Material material)
    {
        foreach (var spriteRendererOriginal in spriteRendererOriginals)
            spriteRendererOriginal.spriteRenderer.material = material;
    }


}
