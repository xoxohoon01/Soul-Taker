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
        StopAnimation(stateMachine.Monster.animationData.RunParameterHash);
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
            StopAnimation(stateMachine.Monster.animationData.RunParameterHash);
            StartAnimation(stateMachine.Monster.animationData.IdleParameterHash);

            if (CanAttack() && IsTargetInFieldOfView())
            {
                lastAttackTime = Time.time;
                StopAnimation(stateMachine.Monster.animationData.IdleParameterHash);
                stateMachine.ChangeState(stateMachine.AttackState);
                return;
            }
        }
        else
        {
            stateMachine.Monster.agent.speed = stateMachine.Monster.status.MoveSpeed.GetValue();
            StopAnimation(stateMachine.Monster.animationData.IdleParameterHash);
            StartAnimation(stateMachine.Monster.animationData.RunParameterHash);
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
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.Monster.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Monster.monsterData.attackRange * stateMachine.Monster.monsterData.attackRange;
    }

    private bool CanAttack()
    {
        return Time.time - lastAttackTime > attackRate;
    }

    private void RotateToTarget()
    {
        Vector3 directionToTarget = GetTargetDirection();
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
        stateMachine.Monster.transform.rotation = Quaternion.Slerp(stateMachine.Monster.transform.rotation, targetRotation, 10f * Time.deltaTime);
    }
}
