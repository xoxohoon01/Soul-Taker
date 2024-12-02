using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public VirtualJoystick joystick;
    public Vector2 input;

    //PC Test
    private float horizontal;
    private float vertical;

    private void Update()
    {
        input = joystick.Direction;

        //PC Test
        if (joystick == null || joystick.Direction == Vector2.zero)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            input = (Vector2.right * horizontal + Vector2.up * vertical).normalized;
        }
    }
}