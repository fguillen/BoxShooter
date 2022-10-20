using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPicker : MonoBehaviour
{
    [SerializeField] int healthBoost = 1;

    public void PickUp(Agent agent)
    {
        agent.damageManager.AddHealth(healthBoost);
    }
}
