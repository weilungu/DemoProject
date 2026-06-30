using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;
    PlayerStateContext ctx;
    
    Rigidbody2D rb;
    PlayerInput input;
    Animator anim;
    PlayerMovement movement;
    
    // == Unity API == //
    void Awake()
    {
        // Get Components
        input = GetComponent<PlayerInput>();
        anim = GetComponentInChildren<Animator>();
        
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        
        
        // Get States with Hash Table
        stateTable = new Dictionary<Type, IState>(states.Length);
        
        // Initialization
        ctx = new PlayerStateContext(rb, input, anim, movement);
        foreach (PlayerState st in states)
        {
            st.Initialize(ctx, stateMachine: this);
            stateTable.Add(st.GetType(), st);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
