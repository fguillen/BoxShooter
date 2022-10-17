using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;

namespace Sensors
{
    public class PlayerInAreaSensor: BoxSensor
    {
        [SerializeField] bool staticPosition;
        Vector2 originalPosition;

        protected override void PostInitialize()
        {
            originalPosition = transform.position;
        }

        void Update()
        {
            if(staticPosition)
                transform.position = originalPosition;
        }
    }
}
