using UnityEngine;


namespace AI
{
    public class BehaviourChasePlayer : AgentBehaviour
    {
        [SerializeField] float waitingTime = 1f;

        Vector2 destinyPosition;
        bool isChasing = false;
        bool isWaiting = false;

        public override void Perform()
        {
            if(!isChasing && !isWaiting)
                CheckForPlayerInArea();

            if(!isChasing || isWaiting)
                return;

            MoveTowardsDestinyPosition();
            CheckIfEndOfPath();
            CheckIfPlayerInFront();
        }

        void CheckIfEndOfPath()
        {
            if(
                agent.wallInFrontSensor.HasHit() ||
                !agent.endOfGroundSensor.HasHit()
            )
                Arrived();
        }

        void CheckIfPlayerInFront()
        {
            if(agent.playerInFrontSensor.HasHit())
                Attack();
        }

        void CheckForPlayerInArea()
        {
            if(agent.playerInAreaSensor.HasHit())
                Chase(agent.playerInAreaSensor.hits[0].transform.position);
        }

        void Chase(Vector2 position)
        {
            destinyPosition = position;
            isChasing = true;
        }

        void Arrived()
        {
            isChasing = false;
            isWaiting = true;
            Invoke("UnsetIsWaiting", waitingTime);

            Vector2 direction = new Vector2(0f, agent.movementData.agentMovement.y).normalized;
            agent.agentInput.CallMovement(direction);
        }

        void MoveTowardsDestinyPosition()
        {
            Vector2 direction = new Vector2(destinyPosition.x - agent.transform.position.x, agent.movementData.agentMovement.y).normalized;
            agent.agentInput.CallMovement(direction);
        }

        void Attack()
        {
            Arrived();
            agent.agentInput.CallAttack();
        }

        void UnsetIsWaiting()
        {
            isWaiting = false;
        }

    }
}
