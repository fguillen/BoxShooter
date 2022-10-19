using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewProjectileData", menuName = "Weapons/Throwable")]
    public class WeaponThrowableData : AWeaponData
    {
        [SerializeField] public float range = 10f;
        [SerializeField] public float speed = 2f;
        [SerializeField] GameObject weaponPrefab;
        [SerializeField] public GameObject explosionPrefab;

        public override bool CanBeUsed(Agent agent)
        {
            return true;
        }

        public override void Attack(Agent agent)
        {
            GameObject weaponObject = Instantiate(weaponPrefab, agent.weaponManager.transform.position, Quaternion.identity);
            weaponObject.GetComponent<Projectile>().Initialize(agent, this);

            agent.weaponManager.ToggleWeaponVisibility(false);
        }
    }
}
