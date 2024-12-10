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

        StartAnimation(HashDataManager.basicAttackParameterHash);
        stateMachine.Monster.animator.SetInteger("SkillIndex", stateMachine.Monster.skillIndex);
        //int skillDataIndex = DataManager.Instance.Skill.GetSkill(stateMachine.Monster.monsterData.skillList[stateMachine.Monster.skillIndex]);
        //stateMachine.Monster.CreateSkill(skillDataIndex);
    }

    public override void Exit()
    {
        StopAnimation(HashDataManager.basicAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsAttackAnimation(stateMachine.Monster.animator, "Skill"))
        {
            stateMachine.ChangeState(stateMachine.ChaseState);
            return;
        }
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
