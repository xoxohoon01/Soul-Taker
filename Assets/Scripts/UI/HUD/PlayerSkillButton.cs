using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSkillButton : UIBase, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool isClick;
    private Skill currentSkill;

    void UseSkill()
    {
        PlayerStateMachine playerStateMachine = PlayerManager.Instance.player.controller.stateMachine;
        if (playerStateMachine.playerController.attackDelay <= 0)
        {
            playerStateMachine.ChangeState(new PlayerBasicAttackState(playerStateMachine));
        }
    }

    public void SetSkill(Skill skill)
    {
        currentSkill = skill;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }

    private void Update()
    {
        if (isClick)
        {
            UseSkill();
        }
    }
}
