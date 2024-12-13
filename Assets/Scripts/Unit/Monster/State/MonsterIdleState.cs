using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    private float wanderCoolDownTime;

    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        wanderCoolDownTime = 0f;
        stateMachine.Monster.agent.isStopped = true;
        StartAnimation(HashDataManager.idleParameterHash);
    }

    public override void Exit()
    {
        StopAnimation(HashDataManager.idleParameterHash);
    }

    public override void Update()
    {
        base.Update();

        wanderCoolDownTime += Time.deltaTime;

        if ((IsTargetInFieldOfView() && IsInDetectRange()) || stateMachine.IsAttacked)
        {
            if (IsInAttackRange())
            {
                stateMachine.ChangeState(stateMachine.WaitingAttackState);
            }
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }

        if (wanderCoolDownTime > stateMachine.Monster.data.wanderRate)
        {
            stateMachine.ChangeState(stateMachine.WanderState);
            return;
        }
    }
}
