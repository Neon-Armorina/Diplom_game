using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FSM.Scripts;

public class Fsm 
{
    private FSMState StateCurrent { get; set; }

    private Dictionary<Type, FSMState> _states = new Dictionary<Type, FSMState>();

    public void AddState(FSMState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FSMState
    {
        var type = typeof(T);
        
        if (StateCurrent != null && StateCurrent.GetType() == null)
        {
            return;
        }

        if (_states.TryGetValue(type, out var newState))
        {
            StateCurrent?.Exit();
            StateCurrent = newState;
            StateCurrent.Enter();
        }
    }

    public void Update()
    {
        StateCurrent?.Update();
    }
}
