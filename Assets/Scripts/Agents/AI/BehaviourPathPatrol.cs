using UnityEngine;


namespace AI
{
    public class BehaviourPathPatrol : AgentBehaviour
    {
        [SerializeField] Path path;
        [SerializeField] float distanceToPoint = 0.5f;
        [SerializeField] float waitingTime;

        Vector2 currentPoint;
        bool isWaiting = false;

        public override void Perform()
        {
            if(isWaiting)
                return;

            MoveToCurrentPoint();

            if(CheckIfArriveToPoint())
                ArrivedToPoint();
        }

        public override void PostInitialize()
        {
            currentPoint = path.ClosestPoint(agent.transform.position);
        }

        bool CheckIfArriveToPoint()
        {
            return (currentPoint - (Vector2)agent.transform.position).magnitude < distanceToPoint;
        }

        void ArrivedToPoint()
        {
            isWaiting = true;
            agent.agentInput.CallMovement(Vector2.zero);
            Invoke("EndWaiting", waitingTime);
        }

        void EndWaiting()
        {
            isWaiting = false;
            NextPoint();
        }

        void MoveToCurrentPoint()
        {
            Vector2 direction = (currentPoint - (Vector2)agent.transform.position).normalized;
            if(agent.movementData.agentMovement != direction)
                agent.agentInput.CallMovement(direction);
        }

        void NextPoint()
        {
            currentPoint = path.NextPoint(currentPoint);
        }
    }
}
