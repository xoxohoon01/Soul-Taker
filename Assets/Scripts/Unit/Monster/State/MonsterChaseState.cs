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
        stateMachine.Monster.agent.isStopped = false;
        stateMachine.Monster.agent.speed = stateMachine.Monster.status.MoveSpeed.GetValue();
        stateMachine.Monster.agent.SetDestination(stateMachine.Target.transform.position);

        attackRate = 1f / stateMachine.Monster.status.AttackSpeed.GetValue();
    }

    public override void Exit()
    {
        stateMachine.Monster.agent.isStopped = true;
        StopAnimation(HashDataManager.runParameterHash);
    }

    public override void Update()
    {
        base.Update();

        stateMachine.Monster.agent.SetDestination(stateMachine.Target.transform.position);

        if (!IsInDetectRange())
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            stateMachine.IsAttacked = false;
            return;
        }

        if (IsInAttackRange())
        {
            RotateToTarget();
            stateMachine.Monster.agent.SetDestination(stateMachine.Monster.transform.position);
            StopAnimation(HashDataManager.runParameterHash);
            StartAnimation(HashDataManager.idleParameterHash);

            if (CanAttack() && IsTargetInFieldOfView())
            {
                lastAttackTime = Time.time;
                StopAnimation(HashDataManager.idleParameterHash);
                stateMachine.ChangeState(stateMachine.AttackState);
                return;
            }
        }
        else
        {
            stateMachine.Monster.agent.speed = stateMachine.Monster.status.MoveSpeed.GetValue();
            StopAnimation(HashDataManager.idleParameterHash);
            StartAnimation(HashDataManager.runParameterHash);
        }
    }

    public override void HandleInput()
    {
    }
    public override void PhysicsUpdate()
    {
    }

    private bool CanAttack()
    {
        return Time.time - lastAttackTime > attackRate;
    }
}
