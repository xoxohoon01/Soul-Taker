using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected PlayerStateMachine stateMachine;


    public Vector2 MovementInput;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void HandleInput()
    {
        ReadInput();
    }

    public virtual void PhysicsUpdate() { }

    public virtual void Update() { }

    public void StartAnimation(int animationHash)
    {
        stateMachine.playerController.animator.SetBool(animationHash, true);
    }

    public void StopAnimation(int animationHash)
    {
        stateMachine.playerController.animator.SetBool(animationHash, false);
    }

    public void ReadInput()
    {
        stateMachine.MovementInput = stateMachine.playerController.Input.input;

        //stateMachine.MovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
