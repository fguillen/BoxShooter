using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IntroCircles : MonoBehaviour
{
    [SerializeField] float rotationTime = 10f;
    [SerializeField] float maxScale = 6f;
    [SerializeField] float scaleTime = 2f;


    List<Transform> circles;

    void Awake()
    {
        circles = transform.Find("Circles").GetChildren();
    }

    // Start is called before the first frame update
    void Start()
    {
        RotateCircles();
        RandomMaterialParameters();
        ScaleCircles();
    }

    void RotateCircles()
    {
        foreach (var circle in circles)
        {
            DOTweenUtils.DirectionType direction = RandomUtils.RandomBetween2Values(DOTweenUtils.DirectionType.ClockWise, DOTweenUtils.DirectionType.CounterClockWise);
            float _rotationTime = RandomUtils.AddRandomOffset(rotationTime, rotationTime / 2f);
            DOTweenUtils.Rotate360(circle, _rotationTime, direction, true);
        }
    }

    void RandomMaterialParameters()
    {
        foreach (var circle in circles)
        {
            float windSpeed = circle.GetComponent<SpriteRenderer>().material.GetFloat("_WindSpeed");
            windSpeed = RandomUtils.AddRandomOffset(windSpeed, windSpeed / 2f);
            circle.GetComponent<SpriteRenderer>().material.SetFloat("_WindSpeed", windSpeed);
        }
    }

    void ScaleCircles()
    {
        foreach (var circle in circles)
        {
            Vector2 originalScale = circle.localScale;
            float _scaleTime = RandomUtils.AddRandomOffset(scaleTime, scaleTime / 2f);
            circle.DOScale(originalScale * maxScale, _scaleTime).SetEase(Ease.Linear);
        }
    }
}
