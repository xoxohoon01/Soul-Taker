using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerInput Input;
    public Rigidbody rb;
    public Transform mainMesh;
    public PlayerStateMachine stateMachine;
    public PlayerWeapon weapon;
    public Animator Animator { get; private set; }

    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();
        Input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        stateMachine = new PlayerStateMachine(this);
        weapon = GetComponentInChildren<PlayerWeapon>();
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void Attack()
    {
        stateMachine.IsAttacking = true;
        weapon.UseWeapon();
    }
}
