using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DataTable;

public class PlayerSkillButton : UIBase, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool isClick;
    private SkillData currentSkill;

    void UseSkill()
    {
        PlayerStateMachine playerStateMachine = PlayerManager.Instance.player.controller.stateMachine;
        if (playerStateMachine.playerController.skill1Cooldown <= 0)
        {
            playerStateMachine.ChangeState(new SamuraiSwordSpiritState(playerStateMachine));
        }
    }

    public void SetSkill(SkillData skill)
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
