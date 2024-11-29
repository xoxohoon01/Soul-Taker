using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackButton : MonoBehaviour
{
    [SerializeField] private GameObject coolDownUI;
    private Image coolDownImage;

    [SerializeField] private float attackCoolDownTime;
    private float coolDownFilled;

    private void Awake()
    {
        coolDownImage = coolDownUI.GetComponent<Image>();
    }

    public void Attack()
    {
        CharacterManager.Instance.Player.Behavior.Attack();
        StartCoroutine(CheckCoolDown());
    }

    IEnumerator CheckCoolDown()
    {
        coolDownUI.SetActive(true);

        float coolDown = attackCoolDownTime;

        while (coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
            coolDownFilled = coolDown / attackCoolDownTime;
            coolDownImage.fillAmount = coolDownFilled;
            yield return null;
        }

        coolDownUI.SetActive(false);
    }
}
