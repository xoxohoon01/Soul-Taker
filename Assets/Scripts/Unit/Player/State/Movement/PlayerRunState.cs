using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerMovementState
{
    public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.playerController.animationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.playerController.rb.velocity = Vector3.zero;
        StopAnimation(stateMachine.playerController.animationData.RunParameterHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        // 가상패드 조작 멈출 시 Idle 상태로 전환
        if (stateMachine.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine));
        }
    }

    public override void PhysicsUpdate()
    {
        Move();
    }

    public void Move()
    {
        stateMachine.playerController.rb.velocity = new Vector3(stateMachine.MovementInput.x, 0, stateMachine.MovementInput.y).normalized * stateMachine.status.MoveSpeed.GetValue();
        if (stateMachine.MovementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(stateMachine.playerController.rb.velocity, Vector3.up);
            stateMachine.playerController.transform.rotation = Quaternion.Slerp(stateMachine.playerController.transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}
