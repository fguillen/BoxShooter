using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

namespace Sensors
{
    public class RaySensor : MonoBehaviour
    {
        [SerializeField] bool drawGizmos;
        [SerializeField] Color gizmosColorHit = Color.red;
        [SerializeField] Color gizmosColorHitObstacle = Color.blue;
        [SerializeField] Color gizmosColorNoHit = Color.green;
        [SerializeField] LayerMask obstacleLayerMask;
        [SerializeField] LayerMask objectiveLayerMask;
        [SerializeField] Transform limit;

        public RaycastHit2D hit { get; private set; }
        bool hasHit;
        bool hasHitObstruction;

        public bool HasHit()
        {
            CheckHit();
            return hasHit;
        }

        void CheckHit()
        {
            hit =
                Physics2D.Linecast(
                    transform.position,
                    limit.position,
                    objectiveLayerMask | obstacleLayerMask
                );

            if(hit.collider != null)
            {
                // If the hitted object is in the obstacleLayerMask return false
                if(LayerUtils.InLayerMask(hit.collider.gameObject.layer, obstacleLayerMask))
                {
                    hasHit = false;
                    hasHitObstruction = true;
                }
                else
                {
                    hasHit = true;
                    hasHitObstruction = false;
                }
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

            CheckHit();

            if(hasHit)
            {
                Gizmos.color = gizmosColorHit;
                Gizmos.DrawSphere(hit.centroid, 0.1f);
            }
            else if(hasHitObstruction)
            {
                Gizmos.color = gizmosColorHitObstacle;
                Gizmos.DrawSphere(hit.centroid, 0.1f);
            }
            else
                Gizmos.color = gizmosColorNoHit;

            Gizmos.DrawLine(transform.position, limit.position);
        }
    }
}
