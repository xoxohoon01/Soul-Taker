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
        if (joystick != null)
            input = joystick.Direction;

        //PC Test
        if (joystick == null || joystick.Direction == Vector2.zero)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            input = (Vector2.right * horizontal + Vector2.up * vertical).normalized;
        }
    }

    public void ConnectJoyStick()
    {
        joystick = VirtualJoystick.Instance;
    }
}