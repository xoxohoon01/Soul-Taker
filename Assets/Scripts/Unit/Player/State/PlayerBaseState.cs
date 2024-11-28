using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void Update()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        Movement();
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.PlayerBehavior.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.PlayerBehavior.Animator.SetBool(animationHash, false);
    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.PlayerBehavior.Input.input;
    }

    private void Movement()
    {
        Vector3 moveDirection = GetMoveDirection();
        Rotate(moveDirection);
        Move(moveDirection);
    }

    private Vector3 GetMoveDirection()
    {
        return (Vector3.forward * stateMachine.MovementInput.y
                + Vector3.right * stateMachine.MovementInput.x).normalized;
    }

    private void Move(Vector3 direction)
    {
        float moveSpeed = GetMoveSpeed();
        stateMachine.PlayerBehavior.rb.velocity = direction * moveSpeed;
    }

    private void Rotate(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        float rotationY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        stateMachine.PlayerBehavior.mainMesh.rotation = Quaternion.Euler(0, rotationY, 0);
    }

    private float GetMoveSpeed()
    {
        float moveSpeed = CharacterManager.Instance.Player.Status.MoveSpeed.CurrentValue;
        return moveSpeed;
    }
}
