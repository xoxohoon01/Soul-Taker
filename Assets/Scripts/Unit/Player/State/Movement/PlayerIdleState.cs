using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerMovementState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.isStop = true;
        base.Enter();
        StartAnimation(HashDataManager.idleParameterHash);
    }
    public override void Exit()
    {
        stateMachine.isStop = false;
        base.Exit();
        StopAnimation(HashDataManager.idleParameterHash);
    }

    // 가상패드 조작 시 Run 상태로 전환
    public override void HandleInput()
    {
        base.HandleInput();
        if (stateMachine.MovementInput != Vector2.zero)
        {
            stateMachine.ChangeState(new PlayerRunState(stateMachine));
        }
    }
}
