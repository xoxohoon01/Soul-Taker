using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(HashDataManager.attackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(HashDataManager.attackParameterHash);
    }
}
