using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackWhiteFlash : MonoBehaviour, IFeedback
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float durationSeconds = 0.1f;
    [SerializeField] Material solidColorMaterial;
    Material originalMaterial;

    void Awake()
    {
        originalMaterial = spriteRenderer.material;

        if(solidColorMaterial == null || !solidColorMaterial.HasProperty("Active"))
            throw new Exception("Material not found or has no 'Active' property");
    }

    public void Perform()
    {
        StopAllCoroutines();
        ToggleActive(true);
        StartCoroutine(ToggleDeactivateCoroutine());
    }

    void ToggleActive(bool val)
    {
        if(val)
        {
            spriteRenderer.material = solidColorMaterial;
            solidColorMaterial.SetFloat("Active", 1f);
        } else
        {
            spriteRenderer.material = originalMaterial;
            solidColorMaterial.SetFloat("Active", 0f);
        }
    }

    IEnumerator ToggleDeactivateCoroutine()
    {
        yield return new WaitForSeconds(durationSeconds);
        ToggleActive(false);
    }
}
