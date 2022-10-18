using System;
using UnityEngine;


namespace AI
{
    public abstract class AgentBehaviour : MonoBehaviour
    {
        public AgentBrain brain { get; private set; }
        public Agent agent { get; private set; }

        public void Initialize(AgentBrain brain)
        {
            this.brain = brain;
            this.agent = brain.agent;

            PostInitialize();
        }

        public virtual void PostInitialize() {}
        public abstract void Perform();
    }
}
