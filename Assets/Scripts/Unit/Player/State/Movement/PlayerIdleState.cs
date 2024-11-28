using UnityEngine;

public class PlayerIdleState : PlayerMovementState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.IsStop = true;
        base.Enter();
        StartAnimation(stateMachine.PlayerBehavior.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.PlayerBehavior.AnimationData.IdleParameterHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (stateMachine.MovementInput != Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.RunState);
            return;
        }
    }
}