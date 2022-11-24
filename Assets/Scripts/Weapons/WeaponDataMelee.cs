using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "NewMeleeWeaponData", menuName = "Weapons/Melee")]
    public class WeaponDataMelee : AWeaponData
    {
        public float range = 2f;

        public override bool CanBeUsed(Agent agent)
        {
            return true;
        }

        public override void Attack(Agent agent)
        {
            Debug.Log($"WeaponDataMelee.Attack(), Direction: {Direction(agent)}");

            RaycastHit2D hit =
                Physics2D.Raycast(
                    agent.weaponManager.transform.position,
                    Direction(agent),
                    range,
                    hittableMask
                );

            if(hit.collider != null)
            {
                Debug.Log($"Hit something ({hit.collider.gameObject.name})");

                foreach (var hittable in hit.collider.GetComponents<IHittable>())
                {
                    if(hittable.Agent() != agent)
                    {
                        Debug.Log($"Sending Hit");
                        hittable.GetHit(damage, agent.transform.position);
                    }
                }
            }
        }

        public override void DrawGizmo(Agent agent)
        {
            Vector2 origin = agent.weaponManager.transform.position;
            Vector2 destiny = agent.weaponManager.transform.position + (Vector3)(Direction(agent) * range);
            // Debug.Log($"DrawGizmo: [{origin}], [{destiny}]");
            Gizmos.color = Color.red;
            Gizmos.DrawLine(origin, destiny);
        }

        Vector2 Direction(Agent agent)
        {
            return agent.movementData.movementLastDirection;
        }
    }
}
