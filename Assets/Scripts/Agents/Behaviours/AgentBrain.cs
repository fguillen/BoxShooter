using System;
using UnityEngine;

namespace AI
{
    public class AgentBrain : MonoBehaviour
    {
        [HideInInspector] public Agent agent;

        void Awake()
        {
            agent = GetComponentInChildren<Agent>();

            if(agent == null)
                throw new Exception($"Agent component not found'");
        }
    }
}
