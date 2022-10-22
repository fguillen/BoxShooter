using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PointsUI : MonoBehaviour
{
    TextMeshProUGUI pointsText;
    public UnityEvent OnPointsChange;

    void Awake()
    {
        pointsText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetPoints(int points)
    {
        pointsText.SetText(points.ToString());
        OnPointsChange?.Invoke();
    }
}
