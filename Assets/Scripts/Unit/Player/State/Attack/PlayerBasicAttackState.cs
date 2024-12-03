using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttackState : PlayerAttackState
{
    public PlayerBasicAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.playerController.animationData.BasicAttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.playerController.animationData.BasicAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.playerController.attackDelay <= 0)
        {
            stateMachine.playerController.attackDelay = 1 / stateMachine.status.AttackSpeed.GetValue();
            GameObject attack = Resources.Load<GameObject>("PlayerAttack");
        }
    }
}
