using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    protected Dictionary<Type, IState> stateTable;

    
    // == Unity API == //
    void Update()
    {
        currentState.LogicalUpdate();
    }

    void FixedUpdate()
    {
        currentState.PhysicalUpdate();
    }
    
    
    // == Self Method == //
    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    public void SwitchState(Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }
}
