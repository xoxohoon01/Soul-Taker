using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Test Variable
    public VirtualJoystick joystick;
    public Rigidbody rb;
    public Transform mainMesh;
    private Vector3 moveDirection;
    public float moveSpeed = 5f;
    private float horizontal;
    private float vertical;

    private void Update()
    {
        //Test용 입력 이동
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
    }

    public void FixedUpdate()
    {
        if (joystick.Direction != Vector2.zero)
        {
            moveDirection = (Vector3.forward * joystick.Direction.y + Vector3.right * joystick.Direction.x).normalized;
        }

        rb.velocity = moveDirection * moveSpeed;

        RotationToMoveDirection(moveDirection);
    }

    private void RotationToMoveDirection(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        float rotationY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        mainMesh.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}