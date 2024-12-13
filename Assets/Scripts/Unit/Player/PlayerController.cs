using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public PlayerInput Input;
    public Rigidbody rb;
    public PlayerStateMachine stateMachine;
    public GameObject cameraContainer;

    [HideInInspector] public Animator animator;

    public Coroutine coroutineCombo;
    public int comboIndex;
    public float attackDelay;
    public float attackSpan;

    public float[] skillCooldown = new float[4];
    
    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        Input = GetComponent<PlayerInput>();
        skillCooldown = new float[4];

        cameraContainer = new GameObject("CameraContainer");
        cameraContainer.transform.SetParent(transform);
        cameraContainer.transform.localPosition = new Vector3(0, 1.5f, 0);

        Camera.main.transform.SetParent(cameraContainer.transform);
        Camera.main.transform.localPosition = new Vector3(0, 7, -8);
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
        skillCooldown[0] = Mathf.Max(skillCooldown[0] - Time.deltaTime, 0);
        skillCooldown[1] = Mathf.Max(skillCooldown[1] - Time.deltaTime, 0);
        skillCooldown[2] = Mathf.Max(skillCooldown[2] - Time.deltaTime, 0);
        skillCooldown[3] = Mathf.Max(skillCooldown[3] - Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private void LateUpdate()
    {
        Rotation();
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

    private void Rotation()
    {
        cameraContainer.transform.rotation = Quaternion.Euler(LookController.Instance.secondRotation);
    }

}
