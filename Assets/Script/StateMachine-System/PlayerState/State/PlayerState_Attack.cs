using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attack", fileName = "PlayerState_Attack")]
public class PlayerState_Attack : PlayerState
{
    public override void Enter()
    {
        ctx.anim.Play("Attack", 0, 0f);
    }

    public override void LogicalUpdate()
    {
        AnimatorStateInfo stateInfo = ctx.anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime < 1f) return;
        
        stateMachine.SwitchState(
            ctx.input.Move
                ? typeof(PlayerState_Move)
                : typeof(PlayerState_Idle)
        );
    }

    public override void PhysicalUpdate()
    {
        ctx.rb.velocity = PlayerMovement.Direction * ctx.movement.GetSpeed();
    }
    
}
