using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerMovementState
{
    public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(HashDataManager.runParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.playerController.rb.velocity = Vector3.zero;
        StopAnimation(HashDataManager.runParameterHash);
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
        Camera cam = Camera.main;
        Vector3 camForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 camRight = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
        stateMachine.playerController.rb.velocity = 
            ((camForward * stateMachine.MovementInput.y) + (camRight * stateMachine.MovementInput.x))
            .normalized * stateMachine.status.MoveSpeed.GetValue();

        if (stateMachine.playerController.Input.moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(stateMachine.playerController.rb.velocity, Vector3.up);
            stateMachine.playerController.transform.rotation = Quaternion.Slerp(stateMachine.playerController.transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}
