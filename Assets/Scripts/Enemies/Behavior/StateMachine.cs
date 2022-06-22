using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    /// <summary>
    /// States this machine will use.
    /// First value will be the start state.
    /// </summary>
    public Dictionary<Type, BaseState> states {get; private set;}

    /// <summary>
    /// Current state that is ticking.
    /// </summary>
    public BaseState currentState {get; private set;}

    /// <summary>
    /// Event for state change.
    /// </summary>
    public event Action<BaseState> OnStateChanged;

    /// <summary>
    /// Pause the state machine from updating.
    /// </summary>
    private bool pause;

    /// <summary>
    /// External states setter, typically called on intialization.
    /// </summary>
    public void SetStates(Dictionary<Type, BaseState> states)
    {
        this.states = states;
    }

    /// <summary>
    /// Reset state machine to start state.
    /// </summary>
    public void Reset()
    {
        pause = false;
        currentState = states.Values.First();
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        if (pause)
        {
            return;
        }

        if (currentState == null)
        {
            currentState = states.Values.First();
        }

        Type nextStateType = currentState?.Tick();
        if (nextStateType != null && 
            nextStateType != currentState?.GetType())
        {
            SwitchState(nextStateType);
        }
    }

    /// <summary>
    /// Pauses the state machine.
    /// </summary>
    public void Pause()
    {
        pause = true;
    }

    /// <summary>
    /// Switches state, also invokes event.
    /// </summary>
    private void SwitchState(Type nextStateType)
    {
        currentState = states[nextStateType];
        OnStateChanged?.Invoke(currentState);
    }
}