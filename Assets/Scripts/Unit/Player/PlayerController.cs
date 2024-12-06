using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public PlayerInput Input;
    public Rigidbody rb;
    public PlayerStateMachine stateMachine;

    public Animator animator;
    public PlayerAnimationData animationData;

    public Coroutine coroutineCombo;
    public int comboIndex;
    public float attackDelay;
    public float attackSpan;
    
    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        animationData.Initialize();
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

    public void CreateAttack() // 공격 판정 오브젝트 생성
    {
        PlayerAttack attack = Instantiate(Resources.Load<GameObject>("PlayerAttack"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<PlayerAttack>();
        attack.Initialize(5002, gameObject, stateMachine.status.Damage.GetValue());
    }

    IEnumerator ClearCombo(float time)
    {
        yield return new WaitForSeconds(time);
        comboIndex = 0;
        animator.SetInteger("ComboIndex", 0);
    }
}
