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
        stateMachine.Monster.agent.speed = stateMachine.MoveSpeed;
        StartAnimation(stateMachine.Monster.animationData.RunParameterHash);
        stateMachine.Monster.agent.SetDestination(stateMachine.Target.transform.position);

        attackRate = 1f / stateMachine.AttackSpeed;
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
            stateMachine.Monster.agent.speed = 0f;

            if (CanAttack() && IsTargetInFieldOfView())
            {
                lastAttackTime = Time.time;
                stateMachine.ChangeState(stateMachine.AttackState);
                return;
            }
        }
        else
        {
            stateMachine.Monster.agent.speed = stateMachine.MoveSpeed;
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
        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
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
