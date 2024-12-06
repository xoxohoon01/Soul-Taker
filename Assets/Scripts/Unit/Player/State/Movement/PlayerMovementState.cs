using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(HashDataManager.movementParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(HashDataManager.movementParameterHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

}
