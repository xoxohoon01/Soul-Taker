using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInput Input;
    public Rigidbody rb;
    public PlayerStateMachine stateMachine;

    public Animator animator;
    public PlayerAnimationData animationData;
    
    private void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        animationData.Initialize();
    }

    private void Start()
    {
        stateMachine.ChangeState(new PlayerIdleState(stateMachine));
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
