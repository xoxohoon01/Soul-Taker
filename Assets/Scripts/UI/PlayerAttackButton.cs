using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerAttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject coolDownUI;
    private Image coolDownImage;

    [SerializeField] private float attackCoolDownTime;
    private float coolDownFilled;

    [SerializeField] private bool isClick;

    private void Awake()
    {
        //coolDownImage = coolDownUI.GetComponent<Image>();
    }

    public void Attack()
    {
        PlayerStateMachine playerStateMachine = PlayerManager.Instance.player.controller.stateMachine;
        if (playerStateMachine.playerController.attackDelay <= 0)
        {
            playerStateMachine.ChangeState(new PlayerBasicAttackState(playerStateMachine));
        }
    }

    private void Update()
    {
        if (isClick || Input.GetKey(KeyCode.X))
        {
            Attack();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }
}
