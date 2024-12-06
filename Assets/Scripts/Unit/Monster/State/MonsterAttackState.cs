using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Monster.agent.isStopped = true;
        
        // Apply AttackSpeed to Animation Speed
        if (stateMachine.Monster.status.AttackSpeed.GetValue() > 1f)
        {
            stateMachine.Monster.animator.SetFloat("AttackSpeed", stateMachine.Monster.status.AttackSpeed.GetValue());
        }
        else
        {
            stateMachine.Monster.animator.SetFloat("AttackSpeed", 1);
        }

        StartAnimation(stateMachine.Monster.animationData.AttackParameterHash);
        stateMachine.Monster.monsterWeapon.UseWeapon(stateMachine.Monster.status.Damage.GetValue());
    }

    public override void Exit()
    {
        stateMachine.Monster.agent.isStopped = false;
        StopAnimation(stateMachine.Monster.animationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsAttackAnimation(stateMachine.Monster.animator, "Attack"))
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
            return currentInfo.normalizedTime < 1f;
        }
        else
        {
            return false;
        }
    }
}
