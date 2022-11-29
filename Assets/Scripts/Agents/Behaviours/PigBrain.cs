using System;
using UnityEngine;


namespace AI
{
    public class PigBrain : AgentBrain
    {
        [SerializeField] AgentBehaviour patrolBehaviour;

        void Start()
        {
            patrolBehaviour.Initialize(this);
        }

        void Update()
        {
            patrolBehaviour.Perform();
        }

        [ContextMenu("Attack()")]
        void Attack()
        {
            Debug.Log("Attack()");
            agent.agentInput.CallMovement(new Vector2(-1f, 0f));
            agent.agentInput.CallAttack();
        }
    }
}
