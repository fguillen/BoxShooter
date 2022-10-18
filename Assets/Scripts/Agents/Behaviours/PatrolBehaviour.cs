using UnityEngine;


namespace AI
{
    public class PatrolBehaviour : AgentBehaviour
    {
        [SerializeField] float waitingTimeMax = 5f;

        Vector2 currentMovement;
        bool waiting = false;


        public override void PostInitialize()
        {
            Debug.Log("PatrolBehaviour.PostInitialize()");
            InitCurrentMovement();
        }

        public override void Perform()
        {
            if(waiting)
                return;

            if(agent.movementData.agentMovement != currentMovement)
                agent.agentInput.CallMovement(currentMovement);

            if(agent.wallInFrontSensor.HasHit())
                WallInFront();
        }

        void InitCurrentMovement()
        {
            currentMovement = new Vector2((Random.value > 0.5f ? 1f : -1f), 0f);
        }

        void Turn()
        {
            currentMovement *= new Vector2(-1f, 1f);
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
