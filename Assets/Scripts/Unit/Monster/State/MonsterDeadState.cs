using UnityEngine;

public class MonsterDeadState : MonsterBaseState
{
    public MonsterDeadState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.Monster.agent.isStopped = true;
        stateMachine.Monster.animator.SetTrigger(HashDataManager.dieParameterHash);
    }

    public override void Update()
    {
        if (IsDieAnimationEnd(stateMachine.Monster.animator, "Die"))
        {
            DungeonManager.Instance.MonsterDieCount();
            stateMachine.Monster.gameObject.SetActive(false);
            return;
        }
    }

    private bool IsDieAnimationEnd(Animator animator, string name)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);


        if (currentInfo.IsName(name))
        {
            return currentInfo.normalizedTime >= 1f;
        }
        else
        {
            return false;
        }
    }
}
