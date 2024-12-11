using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public PlayerInput Input;
    public Rigidbody rb;
    public PlayerStateMachine stateMachine;

    [HideInInspector] public Animator animator;

    public Coroutine coroutineCombo;
    public int comboIndex;
    public float attackDelay;
    public float attackSpan;
    
    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        Input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        stateMachine.ChangeState(new PlayerIdleState(stateMachine));
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
        if (attackDelay > 0)
            attackDelay = Mathf.Max(attackDelay - Time.deltaTime, 0);
        if (attackSpan > 0)
            attackSpan = Mathf.Max(attackSpan - Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void CreateAttack(float time) // 공격 판정 오브젝트 생성
    {
        Skill attack = new Skill();
        switch (comboIndex)
        {
            default:
            case 1:
                attack = Instantiate(Resources.Load<GameObject>("Skill"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<Skill>();
                attack.Initialize(5001, gameObject, stateMachine.status.Damage.GetValue(), time);
                break;
            case 2:
                attack = Instantiate(Resources.Load<GameObject>("Skill"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<Skill>();
                attack.Initialize(5002, gameObject, stateMachine.status.Damage.GetValue(), time);
                break;
            case 3:
                attack = Instantiate(Resources.Load<GameObject>("Skill"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<Skill>();
                attack.Initialize(5003, gameObject, stateMachine.status.Damage.GetValue(), time);
                break;
        }
    }

    IEnumerator ClearCombo(float time)
    {
        yield return new WaitForSeconds(time);
        comboIndex = 0;
        animator.SetInteger("ComboIndex", 0);
    }
}
