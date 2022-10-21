using UnityEngine;
using DG.Tweening;

public class UIScalePulsationAnimation : AAnimation
{
    [SerializeField] float finalScale = 2f;
    [SerializeField] float duration = 0.2f;
    [SerializeField] int numLoops = -1;
    [SerializeField] float pauseDuration = 0f;

    [SerializeField] RectTransform rectTransform;

    Vector3 originalScaleV;
    Vector3 finalScaleV;

    void Awake()
    {
        if(rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        originalScaleV = rectTransform.localScale;
    }

    protected override void Animate()
    {
        finalScaleV = Vector3.one * finalScale;
        sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOScale(finalScaleV, duration));
        sequence.Append(rectTransform.DOScale(originalScaleV, duration));
        sequence.AppendInterval(pauseDuration);
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    protected override void Reset()
    {
        rectTransform.localScale = originalScaleV;
    }
}
