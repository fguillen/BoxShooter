using System;
using UnityEngine;


namespace AI
{
    public class BrainShooter : AgentBrain
    {
        [SerializeField] BehaviourAttackWhenPlayerInArea behaviourAttackWhenPlayerInArea;

        void Start()
        {
            behaviourAttackWhenPlayerInArea.Initialize(this);
        }

        void Update()
        {
            behaviourAttackWhenPlayerInArea.Perform();
        }
    }
}
