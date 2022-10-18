using UnityEngine;


namespace AI
{
    public class PatrolBehaviour : AgentBehaviour
    {
        Vector2 currentMovement;

        public override void PostInitialize()
        {
            Debug.Log("PatrolBehaviour.PostInitialize()");
            InitCurrentMovement();
        }

        public override void Perform()
        {
            if(agent.wallInFrontSensor.HasHit())
                Turn();

            if(agent.movementData.agentMovement != currentMovement)
                agent.agentInput.CallMovement(currentMovement);
        }

        void InitCurrentMovement()
        {
            currentMovement = new Vector2((Random.value > 0.5f ? 1f : -1f), 0f);
        }

        void Turn()
        {
            currentMovement *= new Vector2(-1f, 1f);
        }
    }
}
