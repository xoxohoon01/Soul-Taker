using UnityEngine;

public class MonsterChaseState : MonsterBaseState
{
    private float lastAttackTime;
    private float attackRate;

    public MonsterChaseState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Behavior.agent.isStopped = false;
        stateMachine.Behavior.agent.speed = stateMachine.MoveSpeed;
        StartAnimation(stateMachine.Behavior.animationData.RunParameterHash);
        stateMachine.Behavior.agent.SetDestination(stateMachine.Target.transform.position);

        attackRate = 1f / stateMachine.AttackSpeed;
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
            stateMachine.IsAttacked = false;
            return;
        }

        if (IsInAttackRange())
        {
            stateMachine.Behavior.agent.speed = 0f;
            StopAnimation(stateMachine.Behavior.animationData.RunParameterHash);

            if (CanAttack() && IsTargetInFieldOfView())
            {
                lastAttackTime = Time.time;
                stateMachine.ChangeState(stateMachine.AttackState);
                return;
            }
        }
        else
        {
            stateMachine.Behavior.agent.speed = stateMachine.MoveSpeed;
            StartAnimation(stateMachine.Behavior.animationData.RunParameterHash);
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
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Behavior.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }

    private bool CanAttack()
    {
        return Time.time - lastAttackTime > attackRate;
    }
}
