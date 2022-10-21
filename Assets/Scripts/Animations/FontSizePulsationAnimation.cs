using UnityEngine;
using DG.Tweening;
using TMPro;

public class FontSizePulsationAnimation : AAnimation
{
    [SerializeField] float finalSize = 2f;
    [SerializeField] float duration = 0.2f;
    [SerializeField] int numLoops = -1;
    [SerializeField] TextMeshProUGUI text;

    float originalSize;

    void Awake()
    {
        if(text == null)
            text = GetComponent<TextMeshProUGUI>();

        originalSize = text.fontSize;
    }

    protected override void Animate()
    {
        sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => originalSize, SetSize, finalSize, duration));
        sequence.Append(DOTween.To(() => finalSize, SetSize, originalSize, duration));
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    void SetSize(float size)
    {
        text.fontSize = size;
    }

    protected override void Reset()
    {
        text.fontSize = originalSize;
    }
}
