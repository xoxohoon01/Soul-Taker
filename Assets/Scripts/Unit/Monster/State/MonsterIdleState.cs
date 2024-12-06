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
        StartAnimation(stateMachine.Monster.animationData.IdleParameterHash);
    }

    public override void Exit()
    {
        stateMachine.Monster.agent.isStopped = false;
        StopAnimation(stateMachine.Monster.animationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();

        wanderCoolDownTime += Time.deltaTime;

        if ((IsTargetInFieldOfView() && IsInDetectRange()) || stateMachine.IsAttacked)
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }

        if (wanderCoolDownTime > stateMachine.Monster.monsterData.wanderRate)
        {
            stateMachine.ChangeState(stateMachine.WanderState);
            return;
        }
    }

    public override void HandleInput()
    {
    }

    public override void PhysicsUpdate()
    {
    }
}
