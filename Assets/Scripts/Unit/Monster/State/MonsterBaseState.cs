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
        if (stateMachine.Behavior.Status.HP.CurrentValue <= 0)
        {
            stateMachine.ChangeState(stateMachine.DeadState);
            return;
        }
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

        RaycastHit hit;
        Vector3 offset = new Vector3(0, 1, 2);

        if (angle < stateMachine.FieldOfView * 0.5 && !Physics.Raycast(stateMachine.Behavior.transform.position + offset,
                directionToTarget, out hit, stateMachine.DetectRange, stateMachine.Behavior.ObstacleMask))
        { 
            return true;
        }

        return false;
    }

    protected bool IsInDetectRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Behavior.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.DetectRange * stateMachine.DetectRange;
    }
}
