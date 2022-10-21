using UnityEngine;
using DG.Tweening;

public class UIShakeAnimation : AAnimation
{
    [SerializeField] float duration = 1f;
    [SerializeField] float strength = 6f;
    [SerializeField] int vibrato = 6;
    [SerializeField] float randomness = 10f;
    [SerializeField] bool fadeOut = true;

    [SerializeField] int numLoops = -1;
    [SerializeField] float pauseDuration = 0f;

    [SerializeField] RectTransform rectTransform;

    ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Harmonic;
    Quaternion originalRotation;

    void Awake()
    {
        if(rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        originalRotation = rectTransform.localRotation;
    }

    protected override void Animate()
    {
        Vector3 strengthVector = new Vector3(0f, 0f, strength);
        sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOShakeRotation(duration, strengthVector, vibrato, randomness, fadeOut, randomnessMode));
        sequence.AppendInterval(pauseDuration);
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    protected override void Reset()
    {
        rectTransform.localRotation = originalRotation;
    }
}
