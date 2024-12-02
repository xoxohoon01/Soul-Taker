using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Behavior.agent.isStopped = true;
        
        // Apply AttackSpeed to Animation Speed
        if (stateMachine.AttackSpeed > 1f)
        {
            stateMachine.Behavior.Animator.SetFloat("AttackSpeed", stateMachine.AttackSpeed);
        }
        else
        {
            stateMachine.Behavior.Animator.SetFloat("AttackSpeed", 1);
        }

        StartAnimation(stateMachine.Behavior.animationData.AttackParameterHash);
    }

    public override void Exit()
    {
        stateMachine.Behavior.agent.isStopped = false;
        StopAnimation(stateMachine.Behavior.animationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsAttackAnimation(stateMachine.Behavior.Animator, "Attack"))
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

    protected bool IsAttackAnimation(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return true;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime < 1f ? true : false;
        }
        else
        {
            return false;
        }
    }
}
