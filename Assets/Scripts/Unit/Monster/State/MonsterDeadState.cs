using UnityEngine;

public class MonsterDeadState : MonsterBaseState
{
    private bool isDead = false;

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
        if (IsDieAnimationEnd("Die") && isDead == false)
        {
            isDead = true;
            DungeonManager.Instance.MonsterDieCount();
            stateMachine.Monster.gameObject.SetActive(false);
            return;
        }
    }

    private bool IsDieAnimationEnd(string name)
    {
        AnimatorStateInfo currentInfo = stateMachine.Monster.animator.GetCurrentAnimatorStateInfo(0);


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
