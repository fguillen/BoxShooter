using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HooverAnimation : AAnimation
{
    [SerializeField] float distance = 0.2f;
    [SerializeField] float duration = 0.2f;
    [SerializeField] float pauseDuration = 0f;
    [SerializeField] int numLoops = -1;
    [SerializeField] Ease ease;

    Vector2 originalPosition;

    void Awake()
    {
        originalPosition = transform.localPosition;
    }

    protected override void Animate()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveY(originalPosition.y + distance, duration));
        sequence.Append(transform.DOLocalMoveY(originalPosition.y, duration));
        sequence.SetEase(ease);
        sequence.AppendInterval(pauseDuration);
        sequence.SetLoops(numLoops);
        sequence.Play();
    }

    protected override void Reset()
    {
        transform.localPosition = originalPosition;
    }
}
