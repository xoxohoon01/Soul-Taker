using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeadState : MonsterBaseState
{
    public MonsterDeadState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.Behavior.agent.isStopped = true;
        stateMachine.Behavior.Animator.SetTrigger(stateMachine.Behavior.animationData.DieParameterHash);
    }

    public override void Update()
    {
        if (IsDieAnimationEnd(stateMachine.Behavior.Animator, "Die"))
        {
            DungeonManager.Instance.MonsterDieCount();
            stateMachine.Behavior.gameObject.SetActive(false);
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
