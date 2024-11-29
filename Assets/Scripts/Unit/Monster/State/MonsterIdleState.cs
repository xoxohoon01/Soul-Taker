using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    public MonsterIdleState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
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
        if (IsTargetInFieldOfView() && IsInDetectRange())
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
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
