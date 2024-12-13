using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWaitingAttackState : MonsterBaseState
{
    private float lastAttackTime;
    private float attackRate;

    public MonsterWaitingAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.Monster.agent.isStopped = true;
        attackRate = 1f / stateMachine.Monster.status.AttackSpeed.GetValue();

        if (CanAttack() && IsTargetInFieldOfView() && !stateMachine.IsAttacking)
        {
            stateMachine.IsAttacking = true;
            stateMachine.ChangeState(stateMachine.AttackState);
            lastAttackTime = Time.time;
            return;
        }

        StartAnimation(HashDataManager.idleParameterHash);
    }

    public override void Exit()
    {
        StopAnimation(HashDataManager.idleParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Monster.animator.IsInTransition(0) || stateMachine.IsAttacking) return;

        if (IsInAttackRange())
        {
            RotateToTarget();

            if (CanAttack() && IsTargetInFieldOfView() && !stateMachine.IsAttacking)
            {
                stateMachine.IsAttacking = true;
                stateMachine.ChangeState(stateMachine.AttackState);
                lastAttackTime = Time.time;
                return;
            }
        }
        else
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }
    }

    private bool CanAttack()
    {
        return Time.time - lastAttackTime > attackRate;
    }
}
