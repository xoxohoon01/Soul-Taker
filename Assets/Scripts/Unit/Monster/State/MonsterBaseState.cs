using UnityEngine;

public class MonsterBaseState : IState
{
    protected MonsterStateMachine stateMachine;
    public MonsterBaseState(MonsterStateMachine stateMachine)
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
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Behavior.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Behavior.Animator.SetBool(animationHash, false);
    }

    protected Vector3 GetTargetDirection()
    {
        Vector3 directionToTarget = stateMachine.Target.transform.position - stateMachine.Behavior.transform.position;
        return directionToTarget;
    }

    protected bool IsTargetInFieldOfView()
    {
        Vector3 directionToTarget = GetTargetDirection();
        float angle = Vector3.Angle(stateMachine.Behavior.transform.forward, directionToTarget);
        return angle < stateMachine.FieldOfView * 0.5;
    }

    protected bool IsInDetectRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Behavior.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.DetectRange * stateMachine.DetectRange;
    }
}
