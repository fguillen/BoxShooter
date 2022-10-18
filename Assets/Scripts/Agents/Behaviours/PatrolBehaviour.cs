using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;


namespace AI
{
    public class PatrolBehaviour : AgentBehaviour
    {
        [SerializeField] float waitingTimeMax = 5f;

        Vector2 currentDirection;
        bool waiting = false;
        List<Vector2> directions;


        void Awake()
        {
            directions = new List<Vector2>();
            directions.Add(new Vector2(0f, 1f));
            directions.Add(new Vector2(1f, 0f));
            directions.Add(new Vector2(0f, -1f));
            directions.Add(new Vector2(-1f, 0f));
        }

        public override void PostInitialize()
        {
            Debug.Log("PatrolBehaviour.PostInitialize()");
            InitCurrentMovement();
        }

        public override void Perform()
        {
            if(waiting)
                return;

            if(agent.movementData.agentMovement != currentDirection)
                agent.agentInput.CallMovement(currentDirection);

            if(agent.wallInFrontSensor.HasHit())
                WallInFront();
        }

        void InitCurrentMovement()
        {
            currentDirection = directions[Random.Range(0, directions.Count)];
        }

        void Turn()
        {
            List<Vector2> directionsWithWall = agent.wallInAllDirectionsSensor.GetDirectionsWithHit();
            List<Vector2> possibleDirections = directions.Where( e => !directionsWithWall.Contains(e) ).ToList();
            currentDirection = possibleDirections[Random.Range(0, possibleDirections.Count)];
            Debug.Log($"Turn().currentDirection: {possibleDirections} -> {currentDirection}");
        }

        void WallInFront()
        {
            Debug.Log($"WallInFront()");
            waiting = true;
            agent.agentInput.CallMovement(Vector2.zero);
            float waitingTime = Random.Range(0f, waitingTimeMax);
            Debug.Log($"WallInFront().waitingTime: {waitingTime}");

            Invoke("ContinueMoving", waitingTime);
        }

        void ContinueMoving()
        {
            Debug.Log("ContinueMoving");
            waiting = false;
            Turn();
        }


    }
}
