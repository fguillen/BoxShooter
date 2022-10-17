using UnityEngine;

namespace AI
{
    public class BehaviourAttack : AgentBehaviour
    {
        float lastAttackAt = 0;
        [SerializeField] float delayBetweenAttacks = 1f;

        public override void Perform()
        {
            if(lastAttackAt + delayBetweenAttacks > Time.time)
                return;

            if(agent.playerInFrontSensor.HasHit())
            {
                agent.agentInput.CallAttack();
                lastAttackAt = Time.time;
            }
        }
    }
}
