using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;


namespace AI
{
    public class AggressivePatrolBehaviour : AgentBehaviour
    {
        bool waiting = false;
        bool charging = false;
        List<Vector2> directions;
        Vector2 cellDestinationPosition;

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
            SetCellDestinationPosition();
        }

        public override void Perform()
        {
            CheckIfPlayerIsBiteable();

            if(!charging)
                CheckIfPlayerIsVisible();

            if(!waiting)
                CheckIfDestinationArrived();
        }

        private void CheckIfDestinationArrived()
        {
            if(
                Vector2Utils.CloseEnough(agent.transform.position, cellDestinationPosition, 0.05f) ||
                agent.wallInFrontSensor.HasHit()
            )
                DestinationArrived();
        }

        private void CheckIfPlayerIsBiteable()
        {
            if(agent.playerInAreaSensor.HasHit())
                AttackPlayer(agent.playerInAreaSensor.hits.First().transform.position);
        }

        void CheckIfPlayerIsVisible()
        {
            List<Vector2> hits = agent.playerInAllDirectionsSensor.GetDirectionsWithHit();

            if(hits.Count() > 0)
                ChargePlayer(hits.First());
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
                DestinationArrived();
            }
            else
                agent.agentInput.CallMovement(possibleDirections[Random.Range(0, possibleDirections.Count)]);
        }

        void DestinationArrived()
        {
            // Debug.Log($"DestinationArrived()");
            charging = false;
            agent.transform.position = GridUtils.CellPositionByPosition(agent.transform.position); // Center in Cell
            waiting = true;
            agent.agentInput.CallMovement(Vector2.zero);
            float waitingTime = Random.Range(0f, agent.agentData.waitingTimeMax);
            cellDestinationPosition = agent.transform.position;
            // Debug.Log($"DestinationArrived().waitingTime: {waitingTime}");

            Invoke("ContinueMoving", waitingTime);
        }

        void ChargePlayer(Vector2 direction)
        {
            charging = true;
            waiting = false;
            agent.agentInput.CallMovement(direction);
        }

        void AttackPlayer(Vector2 position)
        {
            agent.agentInput.CallMovement(Vector2Utils.DirectionBetweenVectorsDiscrete(agent.transform.position, position));
            agent.agentInput.CallAttack();
        }

        void ContinueMoving()
        {
            // Debug.Log("ContinueMoving");

            if(charging)
                return;

            waiting = false;
            ChangeCurrentDirection();
            SetCellDestinationPosition();
        }

        void Log(string message)
        {
            if(debugEnabled)
                Debug.Log(message);
        }

        void SetCellDestinationPosition()
        {
            Vector2 actualDirection = agent.movementData.agentMovement;
            int freeCellsInFront = CalculateCellsToWall(actualDirection);
            int destinationCellInFront = Random.Range(1, freeCellsInFront);
            Vector2 agentCellIndex = GridUtils.CellIndexByPosition(agent.transform.position);
            Vector2 destinationCellIndex = GridUtils.CellPositionByIndex(agentCellIndex + (actualDirection * destinationCellInFront));
            cellDestinationPosition = GridUtils.CellPositionByIndex(destinationCellIndex);
        }

        int CalculateCellsToWall(Vector2 direction)
        {
            int maxChecks = 10;
            int result = 0;
            Vector2 positionBackup = agent.transform.position;

            while (result < maxChecks)
            {
                if(agent.wallInFrontSensor.HasHit())
                    break;

                agent.transform.position += (Vector3)direction * GridUtils.GridSize();
                result ++;
            }

            agent.transform.position = positionBackup;

            return result;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(cellDestinationPosition, 0.2f);
        }
    }
}
