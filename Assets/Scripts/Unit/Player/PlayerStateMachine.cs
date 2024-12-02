using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerStateMachine(PlayerController controller)
    {
        this.playerController = controller;
    }

    public PlayerController playerController { get; }
    public Status status
    {
        get
        {
            return PlayerManager.Instance.player.status;
        }
    }

    public bool isStop;

    // 패드 입력값
    public Vector2 MovementInput;
}
