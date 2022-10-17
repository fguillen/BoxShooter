using System;
using UnityEngine;


namespace AI
{
    public class BrainPatrol : AgentBrain
    {
        [SerializeField] AgentBehaviour attackBehaviour;
        [SerializeField] AgentBehaviour patrolBehaviour;

        void Start()
        {
            attackBehaviour.Initialize(this);
            patrolBehaviour.Initialize(this);
        }

        void Update()
        {
            if(agent.groundSensor.IsGrounded())
            {
                attackBehaviour.Perform();
                patrolBehaviour.Perform();
            }
        }
    }
}
