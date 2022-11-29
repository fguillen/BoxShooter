using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors
{
    public class ClimbSensor : MonoBehaviour
    {
        [SerializeField] LayerMask climbLayerMask;
        bool _canClimb;
        public bool canClimb
        {
            get { return _canClimb; }
            private set { SetCanClimb(value); }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(LayerUtils.InLayerMask(collision.gameObject.layer, climbLayerMask))
                canClimb = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(LayerUtils.InLayerMask(collision.gameObject.layer, climbLayerMask))
                canClimb = false;
        }

        void SetCanClimb(bool value)
        {
            _canClimb = value;
        }
    }
}
