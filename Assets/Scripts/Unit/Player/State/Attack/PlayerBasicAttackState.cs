using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttackState : PlayerAttackState
{
    public PlayerBasicAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    float span;

    public override void Enter()
    {
        base.Enter();

        span = 1.0f / stateMachine.status.AttackSpeed.GetValue(); //공격 유지 시간 (판정 오브젝트 지속시간, 캐릭터 모션 유지시간)

        StartAnimation(HashDataManager.basicAttackParameterHash);

        // 콤보 체크 
        stateMachine.playerController.comboIndex += stateMachine.playerController.comboIndex < 3 ? 1 : -2;
        stateMachine.playerController.animator.SetInteger("ComboIndex", stateMachine.playerController.comboIndex);

        // 공격속도 계산
        stateMachine.playerController.attackDelay = span;
        stateMachine.playerController.attackSpan = span;

        // 공격 판정 오브젝트 생성
        stateMachine.playerController.CreateAttack(span);

        // 콤보 초기화 코루틴 실행
        if (stateMachine.playerController.coroutineCombo != null) stateMachine.playerController.StopCoroutine(stateMachine.playerController.coroutineCombo);
        stateMachine.playerController.coroutineCombo = stateMachine.playerController.StartCoroutine("ClearCombo", span + 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(HashDataManager.basicAttackParameterHash);
        stateMachine.playerController.animator.speed = 1;
    }

    public override void Update()
    {
        base.Update();

        // 공격속도에 따라 애니메이션 속도 변경
        foreach (AnimatorClipInfo info in stateMachine.playerController.animator.GetNextAnimatorClipInfo(0))
        {
            if (stateMachine.playerController.animator.GetNextAnimatorStateInfo(0).IsName(info.clip.name))
            {
                SetAnimationSpeed(info.clip.length / span);
                break;
            }
        }
        
        if (stateMachine.playerController.attackSpan <= 0)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine));
        }
    }
}
