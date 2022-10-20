using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    [SerializeField] AWeaponData weaponData;

    public void PickUp(Agent agent)
    {
        agent.weaponManager.PickUpWeapon(weaponData);
    }
}
