using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Test Variable
    public VirtualJoystick joystick;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    
    public void FixedUpdate()
    {
        Vector3 direction = (Vector3.forward * joystick.Direction.y + Vector3.right * joystick.Direction.x).normalized;
        rb.velocity = direction * moveSpeed;

        RotationToMoveDirection(direction);
    }

    private void RotationToMoveDirection(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        float rotationY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}