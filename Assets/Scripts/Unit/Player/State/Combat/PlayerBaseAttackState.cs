using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseAttackState : PlayerAttackState
{
    public PlayerBaseAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.IsStop = true;
        base.Enter();
        StartAnimation(stateMachine.PlayerBehavior.AnimationData.BaseAttackParameterHash);
        Debug.Log("Attacking");
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerBehavior.AnimationData.BaseAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (!IsAttackAnimation(stateMachine.PlayerBehavior.Animator, "Attack"))
        {
            stateMachine.IsAttacking = false;
            stateMachine.ChangeState(stateMachine.IdleState);
            Debug.Log("finish Attack");
            return;
        }
    }
}
