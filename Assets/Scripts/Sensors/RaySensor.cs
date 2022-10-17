using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

namespace Sensors
{
    public class RaySensor : MonoBehaviour
    {
        [SerializeField] bool drawGizmos;
        [SerializeField] Color gizmosColorObstacle = Color.red;
        [SerializeField] Color gizmosColorNoObstacle = Color.blue;
        [SerializeField] LayerMask objectiveLayerMask;
        [SerializeField] Transform limit;

        public RaycastHit2D hit { get; private set; }
        bool hasHit;

        public bool HasHit()
        {
            CheckHit();
            return hasHit;
        }

        void CheckHit()
        {
            hit =
                Physics2D.Raycast(
                    transform.position,
                    Direction(),
                    Distance(),
                    objectiveLayerMask
                );

            if(hit.collider != null)
            {
                // if(!hasHit)
                //     Debug.Log($"{GetType().Name}.RaySensor Hitted - {hit.point}, {hit.transform.position}, {hit.collider.tag}, {transform.position}, {Direction()}, {Distance()}");

                hasHit = true;
            }
            else
            {
                // if(hasHit)
                //     Debug.Log($"{GetType().Name}.RaySensor UnHitted");

                hasHit = false;
            }
        }

        void OnDrawGizmos()
        {
            if(!drawGizmos)
                return;

            if(hasHit)
                Gizmos.color = gizmosColorObstacle;
            else
                Gizmos.color = gizmosColorNoObstacle;

            Gizmos.DrawLine(transform.position, limit.position);
        }

        Vector3 Direction()
        {
            return (limit.position - transform.position).normalized;
        }

        float Distance()
        {
            return Mathf.Abs((transform.position - limit.position).magnitude);
        }
    }
}
