using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle",  fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        ctx.anim.Play("Idle");
        
        ctx.movement.StopMove(); // 物理速度切成 (0, 0)
    }

    public override void LogicalUpdate()
    {
        if (ctx.input.Move)
            stateMachine.SwitchState(typeof(PlayerState_Move));

        else if (ctx.input.Attack)
        {
            Debug.Log("Idle -> Attack");
            stateMachine.SwitchState(typeof(PlayerState_Attack));
        }
        
    }
}
