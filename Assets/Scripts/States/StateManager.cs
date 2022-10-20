using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateManager : MonoBehaviour
{
    [SerializeField] List<State> states;

    public State currentState { get; private set; }
    State previousState;

    void Awake()
    {
        states = GetComponentsInChildren<State>().ToList();
    }

    void Update()
    {
        currentState?.StateUpdate();
    }

    void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    public void Initialize(Agent agent)
    {
        foreach (var state in states)
            state.Initialize(agent);
    }

    public void TransitionToState(StateType stateType)
    {
        // Debug.Log($"TransitionToState: {stateType}");

        if(currentState != null && currentState.Type() != StateType.Attack && currentState.Type() != StateType.Hit)
            previousState = currentState;

        currentState?.Exit();
        currentState = GetStateByType(stateType);

        if(currentState == null)
            throw new ArgumentException($"State not found: '{stateType}'");

        if(previousState == null)
            previousState = currentState;

        currentState.Enter();
    }

    public void TransitionToPreviousState()
    {
        TransitionToState(previousState.Type());
    }

    State GetStateByType(StateType type)
    {
        return states.Find((e) => e.Type() == type);
    }
}
