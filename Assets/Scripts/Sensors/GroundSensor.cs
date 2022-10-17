using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sensors
{
    public class GroundSensor : MonoBehaviour
    {
        bool isGrounded;

        List<RaySensor> RaySensors;
        Collider2D insideCollider;
        float lastTimeChecked;

        public bool IsGrounded()
        {
            CheckGrounded();
            return isGrounded;
        }

        void Awake()
        {
            RaySensors = GetComponentsInChildren<RaySensor>().ToList();
            insideCollider = GetComponent<Collider2D>();
        }

        void CheckGrounded()
        {
            isGrounded = false;

            foreach (var RaySensor in RaySensors)
            {
                if(RaySensor.HasHit() && !RaySensor.hit.collider.IsTouching(insideCollider))
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }
}
