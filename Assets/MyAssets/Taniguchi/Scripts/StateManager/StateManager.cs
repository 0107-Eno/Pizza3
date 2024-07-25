using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

    protected BaseState<EState> CurrentState;

    protected bool IsTransitioningState = false;
    void Start() {
        CurrentState.EnterState();
    }
    void Update() {
        EState _nextStateKey=CurrentState.GetNextState();

        if (!IsTransitioningState && _nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if(!IsTransitioningState)
        {
            TransitionToState(_nextStateKey);
        }
    }

    public void TransitionToState(EState stateKey)
    {
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
    }
    void OnTriggerEnter(Collider other) {
        CurrentState.OnTriggerEnter(other);
    }
    void OnTriggerStay(Collider other) {
        CurrentState.OnTriggerStay(other);
    }
    void OnTriggerExit(Collider other) {
        CurrentState.OnTriggerExit(other);
    }
}