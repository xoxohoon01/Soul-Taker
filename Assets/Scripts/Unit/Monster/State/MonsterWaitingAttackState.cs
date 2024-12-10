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

        if (CanAttack() && IsTargetInFieldOfView())
        {
            lastAttackTime = Time.time;
            stateMachine.ChangeState(stateMachine.AttackState);
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
        
        if (IsInAttackRange())
        {
            RotateToTarget();

            if (CanAttack() && IsTargetInFieldOfView())
            {
                lastAttackTime = Time.time;
                stateMachine.ChangeState(stateMachine.AttackState);
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
