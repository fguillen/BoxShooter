using System;
using UnityEngine;


namespace AI
{
    public class BrainRex : AgentBrain
    {
        [SerializeField] AgentBehaviour chaseBehaviour;

        void Start()
        {
            chaseBehaviour.Initialize(this);
        }

        void Update()
        {
            chaseBehaviour.Perform();
        }
    }
}
