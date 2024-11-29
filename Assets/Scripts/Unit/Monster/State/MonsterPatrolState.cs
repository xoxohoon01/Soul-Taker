using UnityEngine;

public class MonsterPatrolState : MonsterBaseState
{
    public MonsterPatrolState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Behavior.agent.isStopped = false;
        stateMachine.Behavior.agent.speed = stateMachine.MoveSpeed;
        StartAnimation(stateMachine.Behavior.animationData.RunParameterHash);
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.Behavior.animationData.RunParameterHash);
    }

    public override void HandleInput()
    {
    }

    public override void PhysicsUpdate()
    {
    }

    public override void Update()
    {
    }
}
