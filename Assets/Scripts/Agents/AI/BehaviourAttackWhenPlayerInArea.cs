using UnityEngine;

namespace AI
{
    public class BehaviourAttackWhenPlayerInArea : AgentBehaviour
    {
        float lastAttackAt = 0;
        [SerializeField] float delayBetweenAttacks = 1f;

        public override void Perform()
        {
            if(lastAttackAt + delayBetweenAttacks > Time.time)
                return;

            if(agent.playerInAreaSensor.HasHit())
            {
                Vector2 direction = DirectionToCollider(agent.playerInAreaSensor.hits[0], agent.transform.position);
                agent.agentInput.CallMovement(direction);
                agent.agentInput.CallAttack();
                lastAttackAt = Time.time;
            }
        }

        Vector2 DirectionToCollider(Collider2D collider, Vector2 position)
        {
            return ((Vector2)collider.transform.position - position).normalized;
        }
    }
}
