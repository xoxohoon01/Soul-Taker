using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    private float patrolCoolDownTime;

    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        patrolCoolDownTime = 0f;
        stateMachine.Behavior.agent.isStopped = true;
        StartAnimation(stateMachine.Behavior.animationData.IdleParameterHash);
    }

    public override void Exit()
    {
        stateMachine.Behavior.agent.isStopped = false;
        StopAnimation(stateMachine.Behavior.animationData.IdleParameterHash);
    }

    public override void Update()
    {
        patrolCoolDownTime += Time.deltaTime;

        if (IsTargetInFieldOfView() && IsInDetectRange())
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }

        if (patrolCoolDownTime > stateMachine.PatrolRate)
        {
            stateMachine.ChangeState(stateMachine.PatrolState);
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
