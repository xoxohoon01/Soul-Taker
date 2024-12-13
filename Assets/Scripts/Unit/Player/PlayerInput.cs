using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public VirtualJoystick moveJoystick;
    public LookController lookController;
    public Vector2 moveInput;
    public Vector2 lookInput;

    //PC Test
    private float horizontal;
    private float vertical;

    private void Update()
    {
        if (moveJoystick != null)
            moveInput = moveJoystick.Input;

        //PC Test
        if (moveJoystick == null || moveJoystick.Input == Vector2.zero)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            moveInput = (Vector2.right * horizontal + Vector2.up * vertical).normalized;
        }
    }

    public void ConnectJoyStick()
    {
        moveJoystick = VirtualJoystick.Instance;
        lookController = LookController.Instance;
    }
}