using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerBehavior PlayerBehavior { get; }
    public PlayerIdleState IdleState { get; }
    public PlayerRunState RunState { get; }
    public Vector2 MovementInput { get; set; }


    public PlayerStateMachine(PlayerBehavior playerBehavior)
    {
        this.PlayerBehavior = playerBehavior;
        IdleState = new PlayerIdleState(this);
        RunState = new PlayerRunState(this);
    }
}
