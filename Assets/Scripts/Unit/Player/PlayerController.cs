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

    public float skill1Cooldown;
    public float skill2Cooldown;
    public float skill3Cooldown;
    
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
        
        // 기본공격 딜레이 계산
        attackDelay = Mathf.Max(attackDelay - Time.deltaTime, 0);
        attackSpan = Mathf.Max(attackSpan - Time.deltaTime, 0);

        // 스킬 딜레이 계산
        skill1Cooldown = Mathf.Max(skill1Cooldown - Time.deltaTime, 0);
        skill2Cooldown = Mathf.Max(skill2Cooldown - Time.deltaTime, 0);
        skill3Cooldown = Mathf.Max(skill3Cooldown - Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void Attack(float time) // 공격 판정 오브젝트 생성
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

    public void Skill(int id)
    {
        Skill skill = Instantiate(Resources.Load<GameObject>("Skill"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<Skill>();
        skill.Initialize(id, gameObject, stateMachine.status.Damage.GetValue(), skill.lifeTime);
    }

    IEnumerator ClearCombo(float time)
    {
        yield return new WaitForSeconds(time);
        comboIndex = 0;
        animator.SetInteger("ComboIndex", 0);
    }
}
