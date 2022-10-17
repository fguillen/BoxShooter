using System;
using UnityEngine;


namespace AI
{
    public class BrainBat : AgentBrain
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
            attackBehaviour.Perform();
            patrolBehaviour.Perform();
        }
    }
}
