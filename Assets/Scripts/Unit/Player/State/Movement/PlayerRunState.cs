using UnityEngine;

public class PlayerRunState : PlayerMovementState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.IsStop = false;
        base.Enter();
        StartAnimation(stateMachine.PlayerBehavior.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerBehavior.AnimationData.RunParameterHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (stateMachine.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}