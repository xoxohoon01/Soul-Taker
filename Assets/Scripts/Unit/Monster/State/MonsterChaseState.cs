using UnityEngine;

public class MonsterChaseState : MonsterBaseState
{
    public MonsterChaseState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Behavior.agent.isStopped = false;
        stateMachine.Behavior.agent.speed = stateMachine.MoveSpeed;
        StartAnimation(stateMachine.Behavior.animationData.RunParameterHash);
    }

    public override void Exit()
    {
        stateMachine.Behavior.agent.isStopped = true;
        StopAnimation(stateMachine.Behavior.animationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Behavior.agent.SetDestination(stateMachine.Target.transform.position);

        if (!IsInDetectRange())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
        else if (IsInAttackRange() && IsTargetInFieldOfView())
        {
            stateMachine.Behavior.agent.SetDestination(stateMachine.Behavior.transform.position);
            stateMachine.ChangeState(stateMachine.AttackState);
            return;
        }
    }

    public override void HandleInput()
    {
    }
    public override void PhysicsUpdate()
    {
    }

    protected bool IsInAttackRange()
    {
        //return stateMachine.Behavior.agent.remainingDistance <= stateMachine.AttackRange;
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Behavior.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }
}
