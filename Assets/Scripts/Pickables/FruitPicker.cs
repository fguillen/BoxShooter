using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class FruitPicker : MonoBehaviour
{
    [SerializeField] int points = 1;

    public void PickUp(Agent agent)
    {
        agent.pointsManager.AddPoints(points);
    }
}
