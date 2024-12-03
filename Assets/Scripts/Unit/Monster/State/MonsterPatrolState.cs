using UnityEngine;
using UnityEngine.AI;

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
        stateMachine.Behavior.agent.SetDestination(GetPatrolLocation());
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
        if (!stateMachine.Behavior.agent.pathPending && stateMachine.Behavior.agent.remainingDistance < 0.5f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            return;
        }

        if (IsTargetInFieldOfView() && IsInDetectRange())
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }
    }

    private Vector3 GetPatrolLocation()
    {
        NavMeshHit hit;
       
        int i = 0;
        do
        {
            NavMesh.SamplePosition(stateMachine.Behavior.transform.position
            + (Random.onUnitSphere * Random.Range(stateMachine.MinPatrolDistance, stateMachine.MaxPatrolDistance)),
            out hit, stateMachine.MaxPatrolDistance, NavMesh.AllAreas);
            i++;
            if (i == 30) break;
        }
        while ((Vector3.Distance(stateMachine.Behavior.transform.position, hit.position) < stateMachine.DetectRange));

        return hit.position;
    }
}
