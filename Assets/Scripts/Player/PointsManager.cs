using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsManager : MonoBehaviour
{
    public UnityEvent<int> OnPointsChange;
    public int points { get; private set; }

    public void AddPoints(int amount)
    {
        points += amount;
        OnPointsChange?.Invoke(points);
    }

    public void Initialize()
    {
        points = 0;
        OnPointsChange?.Invoke(points);
    }
}
