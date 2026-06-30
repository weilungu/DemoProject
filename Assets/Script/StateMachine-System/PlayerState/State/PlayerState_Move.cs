using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Move", fileName = "PlayerState_Move")]
public class PlayerState_Move : PlayerState
{
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int MoveY = Animator.StringToHash("MoveY");

    public override void Enter()
    {
        ctx.anim.Play("Move");
    }

    public override void LogicalUpdate()
    {
        if (!ctx.input.Move) // 切換狀態
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        
        if (ctx.input.Attack)
        {
            stateMachine.SwitchState(typeof(PlayerState_Attack));
            Debug.Log("Move -> Attack");
        }
    }

    public override void PhysicalUpdate()
    {
        ctx.movement.Move();
        
        if (PlayerMovement.Direction != Vector2.zero)
        {
            ctx.anim.SetFloat(MoveX, ctx.input.Horizontal);
            ctx.anim.SetFloat(MoveY, ctx.input.Vertical);
        }
    }
}
