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
        if (stateMachine.Monster.status.HP.CurrentValue <= 0)
        {
            stateMachine.ChangeState(stateMachine.DeadState);
            return;
        }
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Monster.animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Monster.animator.SetBool(animationHash, false);
    }

    protected Vector3 GetTargetDirection()
    {
        Vector3 directionToTarget = stateMachine.Target.transform.position - stateMachine.Monster.transform.position;
        return directionToTarget;
    }

    protected bool IsTargetInFieldOfView()
    {
        Vector3 directionToTarget = GetTargetDirection();
        float angle = Vector3.Angle(stateMachine.Monster.transform.forward, directionToTarget);

        RaycastHit hit;
        Vector3 offset = new Vector3(0, 1, 2);

        if (angle < stateMachine.Monster.monsterData.fieldOfView * 0.5 && !Physics.Raycast(stateMachine.Monster.transform.position + offset,
                directionToTarget, out hit, stateMachine.Monster.monsterData.detectRange, stateMachine.Monster.obstacleMask))
        {
            return true;
        }

        return false;
    }

    protected bool IsInDetectRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Monster.monsterData.detectRange * stateMachine.Monster.monsterData.detectRange;
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Monster.monsterData.attackRange * stateMachine.Monster.monsterData.attackRange;
    }

    protected void RotateToTarget()
    {
        Vector3 directionToTarget = GetTargetDirection();
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
        stateMachine.Monster.transform.rotation = Quaternion.Slerp(stateMachine.Monster.transform.rotation, targetRotation, 10f * Time.deltaTime);
    }

    protected bool IsInAnimationTransition()
    {
        return stateMachine.Monster.animator.IsInTransition(0);
    }
}
