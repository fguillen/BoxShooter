using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class WeaponPicker : MonoBehaviour
{
    [SerializeField] AWeaponData weaponData;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = weaponData.sprite;
    }

    public void PickUp(Agent agent)
    {
        agent.weaponManager.PickUpWeapon(weaponData);
    }
}
