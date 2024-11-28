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
    public Animator Animator { get; private set; }

    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();
        Input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        stateMachine = new PlayerStateMachine(this);
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
}
