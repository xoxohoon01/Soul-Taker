using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_Player : MonoBehaviour
{
    public PlayerStatus status;

    [SerializeField] private Rigidbody rb;
    private TH_PlayerAnimatorController animatorController;


    public void Move()
    {
        rb.velocity = (Vector3.forward * Input.GetAxisRaw("Vertical") + Vector3.right * Input.GetAxisRaw("Horizontal")).normalized * status.MoveSpeed.GetValue();
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            animatorController.animator.SetBool("isMove", true);
        }
        else
        {
            animatorController.animator.SetBool("isMove", false);
        }
    }

    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
        rb = GetComponent<Rigidbody>();
        animatorController = GetComponent<TH_PlayerAnimatorController>();
    }

    private void Start()
    {
        status.EnterDungeon();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
