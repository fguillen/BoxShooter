using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;


namespace AI
{
    public class PatrolBehaviour : AgentBehaviour
    {
        // Vector2 currentDirection;
        bool waiting = false;
        List<Vector2> directions;

        [SerializeField] bool debugEnabled = false;


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
            // Debug.Log("PatrolBehaviour.PostInitialize()");
            ChangeCurrentDirection();
        }

        public override void Perform()
        {
            if(agent.playerInAreaSensor.HasHit())
                PlayerDetected(agent.playerInAreaSensor.hits.First().transform.position);

            if(waiting)
                return;

            // if(agent.movementData.agentMovement != currentDirection)
            //     agent.agentInput.CallMovement(currentDirection);

            if(agent.wallInFrontSensor.HasHit())
                WallInFront();
        }

        void ChangeCurrentDirection()
        {
            Log("Turn()");
            List<Vector2> directionsWithObstacle = agent.wallInAllDirectionsSensor.GetDirectionsWithHit();
            List<Vector2> possibleDirections = directions.Where( e => !directionsWithObstacle.Contains(e) ).ToList();
            Log($"Turns().possibleDirection: {possibleDirections}");

            if(possibleDirections.Count == 0)
            {
                Debug.Log($"Not availableDirections ({agent.transform.position})");
                WallInFront();
            }
            else
                agent.agentInput.CallMovement(possibleDirections[Random.Range(0, possibleDirections.Count)]);
        }

        void WallInFront()
        {
            // Debug.Log($"WallInFront()");
            waiting = true;
            agent.agentInput.CallMovement(Vector2.zero);
            float waitingTime = Random.Range(0f, agent.agentData.waitingTimeMax);
            // Debug.Log($"WallInFront().waitingTime: {waitingTime}");

            Invoke("ContinueMoving", waitingTime);
        }

        void PlayerDetected(Vector2 position)
        {
            agent.agentInput.CallMovement(Vector2Utils.DirectionBetweenVectors(agent.transform.position, position));
            agent.agentInput.CallAttack();
        }

        void ContinueMoving()
        {
            // Debug.Log("ContinueMoving");
            waiting = false;
            ChangeCurrentDirection();
        }

        void Log(string message)
        {
            if(debugEnabled)
                Debug.Log(message);
        }
    }
}
