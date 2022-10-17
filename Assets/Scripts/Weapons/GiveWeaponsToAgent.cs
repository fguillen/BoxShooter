using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class GiveWeaponsToAgent : MonoBehaviour
    {
        public List<AWeaponData> weapons = new List<AWeaponData>();

        void Start()
        {
            Agent agent = GetComponentInChildren<Agent>();

            foreach (var weapon in weapons)
            {
                agent.weaponManager.PickUpWeapon(weapon);
            }
        }
    }
}
