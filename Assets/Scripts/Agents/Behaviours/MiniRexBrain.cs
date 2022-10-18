using System;
using UnityEngine;


namespace AI
{
    public class MiniRexBrain : AgentBrain
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
    }
}
