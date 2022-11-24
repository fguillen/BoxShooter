using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackImmunity : MonoBehaviour
{
    [SerializeField] Collider2D theCollider;
    [SerializeField] List<SpriteRenderer> spriteRenderers;
    [SerializeField] List<SpriteRendererOriginalStruct> spriteRendererOriginals = new List<SpriteRendererOriginalStruct>();
    [SerializeField] float durationSeconds = 1f;
    [SerializeField] float blinkDurationSeconds = 0.2f;
    [SerializeField][Range(0, 1)] float blinkAlpha = 0.5f;

    void Awake()
    {
        spriteRendererOriginals = SpriteRendererOriginalStruct.BuildSpriteRendererOriginalsCollection(spriteRenderers);
    }

    public void Perform()
    {
        Debug.Log("FeedbackImmunity.Perform()");
        StopAllCoroutines();
        ToggleActive(true);
        StartCoroutine(BlinkingCoroutine());
        StartCoroutine(ToggleDeactivateCoroutine());
    }

    void ToggleActive(bool val)
    {
        if(val)
        {
            theCollider.enabled = false;
        } else
        {
            theCollider.enabled = true;
        }
    }

    IEnumerator ToggleDeactivateCoroutine()
    {
        yield return new WaitForSeconds(durationSeconds);
        ToggleActive(false);
    }

    IEnumerator BlinkingCoroutine()
    {
        yield return new WaitForSeconds(blinkDurationSeconds);
        SetAlpha(blinkAlpha);
        yield return new WaitForSeconds(blinkDurationSeconds);
        SetAlphaBack();

        if(!theCollider.enabled)
            StartCoroutine(BlinkingCoroutine());
    }

    void SetAlpha(float alpha)
    {
        foreach (var spriteRenderer in spriteRenderers)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }

    void SetAlphaBack()
    {
        SpriteRendererOriginalStruct.SetOriginalColor(spriteRendererOriginals);
    }
}
