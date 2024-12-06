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
        stateMachine.Monster.agent.speed = stateMachine.MoveSpeed;
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
       
        int i = 0;
        do
        {
            NavMesh.SamplePosition(stateMachine.Monster.transform.position
                                    + (Random.onUnitSphere * Random.Range(stateMachine.MinWanderDistance, stateMachine.MaxWanderDistance)),
                                    out hit, stateMachine.MaxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30) break;
        }
        while ((Vector3.Distance(stateMachine.Monster.transform.position, hit.position) < stateMachine.DetectRange));

        return hit.position;
    }
}
