using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class WeaponManager : MonoBehaviour
    {
        public List<AWeaponData> weapons = new List<AWeaponData>();
        public AWeaponData currentWeapon;
        public UnityEvent<AWeaponData> OnWeaponChange;
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnSingleWeapon;

        [SerializeField] bool drawGizmo;

        Agent agent;
        SpriteRenderer spriteRenderer;

        public void ToggleWeaponVisibility(bool val)
        {
            spriteRenderer.enabled = val;
        }

        public void HandleWeaponChange()
        {
            AWeaponData weapon = NextWeapon();

            if(weapon != null)
                SetCurrentWeapon(weapon);
        }

        public void Initialize(Agent agent)
        {
            this.agent = agent;

            if(weapons.Count() <= 1)
                OnSingleWeapon?.Invoke();
        }

        public bool CanAttack()
        {
            return (currentWeapon != null && currentWeapon.CanBeUsed(agent));
        }

        public void Attack()
        {
            currentWeapon.Attack(agent);
        }

        public void AddWeapon(AWeaponData weaponData)
        {
            int beforeCount = weapons.Count();

            weapons.Add(weaponData);

            if(beforeCount <= 1 && weapons.Count() == 2)
                OnMultipleWeapons?.Invoke();
        }

        public void PickUpWeapon(AWeaponData weaponData)
        {
            AddWeapon(weaponData);
            SetCurrentWeapon(weaponData);
        }

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void SetCurrentWeapon(AWeaponData weaponData)
        {
            currentWeapon = weaponData;
            spriteRenderer.sprite = currentWeapon.sprite;
            OnWeaponChange?.Invoke(weaponData);
        }

        void OnDrawGizmos()
        {
            // Debug.Log($"OnDrawGizmos({!drawGizmo}, {currentWeapon == null}, {!Application.isPlaying}, {agent == null})");

            if(!drawGizmo || currentWeapon == null || agent == null)
                return;

            Gizmos.color = Color.red;
            currentWeapon.DrawGizmo(agent);
        }

        AWeaponData NextWeapon()
        {
            if(weapons.Count() == 1 || currentWeapon == null)
                return null;

            int index = weapons.IndexOf(currentWeapon);
            int nextIndex = index + 1;

            if(nextIndex >= weapons.Count())
                nextIndex = 0;

            return weapons[nextIndex];
        }
    }
}
