using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DataTable;
using UnityEditor.Timeline.Actions;

public class PlayerSkillButton : UIBase, IPointerDownHandler, IPointerUpHandler
{
    public int buttonNumber;

    [SerializeField] private bool isClick;
    private SkillData currentSkill;

    void UseSkill()
    {
        PlayerStateMachine playerStateMachine = PlayerManager.Instance.player.controller.stateMachine;
        if (playerStateMachine.playerController.skillCooldown[buttonNumber] <= 0)
        {
            playerStateMachine.playerController.skillCooldown[buttonNumber] = currentSkill.cooldown;
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

    private void Start()
    {
        SetSkill(SkillData.GetDictionary()[5004]);
    }

    private void Update()
    {
        if (isClick)
        {
            UseSkill();
        }
    }
}
