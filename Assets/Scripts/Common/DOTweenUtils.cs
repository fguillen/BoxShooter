using UnityEngine;
using DG.Tweening;

public static class DOTweenUtils
{
    public enum DirectionType
    {
        ClockWise,
        CounterClockWise
    }

    public static Tween Rotate360(Transform transform, float time, DirectionType direction, bool infinite)
    {
        int directionValue = direction == DirectionType.ClockWise ? -1 : 1;

        Tween tween = transform.DOLocalRotate(new Vector3(0, 0, 360 * directionValue), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);

        if(infinite)
            tween.SetLoops(-1);

        return tween;
    }

    public static Tween Rotate360(Transform transform, float time)
    {
        return Rotate360(transform, time, DirectionType.ClockWise, false);
    }
}
