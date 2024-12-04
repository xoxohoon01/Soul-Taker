using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttackState : PlayerAttackState
{
    public PlayerBasicAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        float span = 1 / stateMachine.status.AttackSpeed.GetValue(); //공격 유지 시간 (판정 오브젝트 지속시간, 캐릭터 모션 유지시간)
        
        StartAnimation(stateMachine.playerController.animationData.BasicAttackParameterHash);

        // 콤보 체크 
        stateMachine.playerController.comboIndex += stateMachine.playerController.comboIndex < 3 ? 1 : -2;
        stateMachine.playerController.animator.SetInteger("ComboIndex", stateMachine.playerController.comboIndex);

        // 공격속도 계산
        stateMachine.playerController.attackDelay = span;
        stateMachine.playerController.attackSpan = span + (span * 0.1f);

        //공겨 판정 오브젝트 생성
        stateMachine.playerController.CreateAttack(span);

        // 현재 애니메이션에 따라 속도 조절 (공격속도 영향받음)
        stateMachine.playerController.animator.speed = stateMachine.playerController.animator.GetCurrentAnimatorStateInfo(0).length + span;

        // 콤보 초기화 코루틴 실행
        if (stateMachine.playerController.coroutineCombo != null) stateMachine.playerController.StopCoroutine(stateMachine.playerController.coroutineCombo);
        stateMachine.playerController.coroutineCombo = stateMachine.playerController.StartCoroutine("ClearCombo", span + 0.5f);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.playerController.animationData.BasicAttackParameterHash);
        stateMachine.playerController.animator.speed = 1;
    }

    public override void Update()
    {
        base.Update();

        stateMachine.playerController.animator.speed = stateMachine.playerController.animator.GetCurrentAnimatorStateInfo(0).length;

        if (stateMachine.playerController.attackSpan <= 0)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine));
        }
    }
}
