using UnityEngine;

public class MonsterChaseState : MonsterBaseState
{
    public MonsterChaseState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Monster.agent.isStopped = false;
        stateMachine.Monster.agent.speed = stateMachine.Monster.status.MoveSpeed.GetValue();
        stateMachine.Monster.agent.SetDestination(stateMachine.Target.transform.position);
        StartAnimation(HashDataManager.runParameterHash);
    }

    public override void Exit()
    {
        stateMachine.Monster.agent.SetDestination(stateMachine.Monster.transform.position);
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
            stateMachine.ChangeState(stateMachine.WaitingAttackState);
            return;
        }
    }
}
