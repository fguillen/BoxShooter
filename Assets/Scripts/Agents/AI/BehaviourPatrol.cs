using UnityEngine;


namespace AI
{
    public class BehaviourPatrol : AgentBehaviour
    {
        Vector2 currentMovement;

        public override void PostInitialize()
        {
             InitCurrentMovement();
        }

        public override void Perform()
        {
            if(
                agent.wallInFrontSensor.HasHit() ||
                !agent.endOfGroundSensor.HasHit()
            )
                Turn();

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
