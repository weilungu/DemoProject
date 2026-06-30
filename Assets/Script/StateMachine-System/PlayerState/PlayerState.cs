using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected PlayerStateContext ctx;
    protected PlayerStateMachine stateMachine;
    
    public void Initialize(PlayerStateContext ctx, PlayerStateMachine stateMachine)
    {
        this.ctx = ctx;
        this.stateMachine = stateMachine;
    }
    
    public virtual void Enter() {}

    public virtual void Exit() {}

    public virtual void LogicalUpdate() {}

    public virtual void PhysicalUpdate() {}
}
