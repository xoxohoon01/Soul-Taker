using UnityEngine;
using UnityEngine.AI;

public class MonsterWanderState : MonsterBaseState
{
    public MonsterWanderState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Monster.agent.isStopped = false;
        stateMachine.Monster.agent.speed = stateMachine.Monster.status.MoveSpeed.GetValue();
        StartAnimation(stateMachine.Monster.animationData.RunParameterHash);
        stateMachine.Monster.agent.SetDestination(GetWanderLocation());
    }

    public override void Exit()
    {
        StopAnimation(stateMachine.Monster.animationData.RunParameterHash);
    }

    public override void HandleInput()
    {
    }

    public override void PhysicsUpdate()
    {
    }

    public override void Update()
    {
        base.Update();
        if ((IsTargetInFieldOfView() && IsInDetectRange()) || stateMachine.IsAttacked)
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }

        if (!stateMachine.Monster.agent.pathPending && stateMachine.Monster.agent.remainingDistance < 0.5f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }
    }

    private Vector3 GetWanderLocation()
    {
        NavMeshHit hit;
       
        NavMesh.SamplePosition(stateMachine.Monster.transform.position
                            + (Random.onUnitSphere * Random.Range(stateMachine.Monster.monsterData.minWanderDistance, stateMachine.Monster.monsterData.maxWanderDistance)),
                            out hit, stateMachine.Monster.monsterData.maxWanderDistance, NavMesh.AllAreas);
        return hit.position;
    }
}
