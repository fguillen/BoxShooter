using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Physics2D;


namespace Sensors
{
    public class SensorInAllDirectionsSensor : MonoBehaviour
    {
        [SerializeField] RaySensor sensorNorth;
        [SerializeField] RaySensor sensorEast;
        [SerializeField] RaySensor sensorSouth;
        [SerializeField] RaySensor sensorWest;

        public List<Vector2> GetDirectionsWithHit()
        {
            List<Vector2> result = new List<Vector2>();

            if(sensorNorth.HasHit())
                result.Add(new Vector2(0f, 1f));

            if(sensorEast.HasHit())
                result.Add(new Vector2(1f, 0f));

            if(sensorSouth.HasHit())
                result.Add(new Vector2(0f, -1f));

            if(sensorWest.HasHit())
                result.Add(new Vector2(-1f, 0f));

            return result;
        }

        public bool HasHitInDirection(Vector2 direction)
        {
            Vector2 directionDiscrete = Vector2Utils.DirectionDiscrete(direction);
            List<Vector2> directionsWithHit = GetDirectionsWithHit();

            return directionsWithHit.Contains(directionDiscrete);
        }
    }
}
