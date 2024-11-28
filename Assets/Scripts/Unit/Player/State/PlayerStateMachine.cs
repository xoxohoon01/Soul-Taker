using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerBehavior PlayerBehavior { get; }
    public PlayerIdleState IdleState { get; }
    public PlayerRunState RunState { get; }
    public PlayerBaseAttackState BaseAttackState { get; }

    public Vector2 MovementInput { get; set; }
    public float MoveSpeed { get; private set; }
    public bool IsStop { get; set; }
    public bool IsAttacking { get; set; }

    public PlayerStateMachine(PlayerBehavior playerBehavior)
    {
        this.PlayerBehavior = playerBehavior;
        IdleState = new PlayerIdleState(this);
        RunState = new PlayerRunState(this);
        BaseAttackState = new PlayerBaseAttackState(this);

        //MoveSpeed = CharacterManager.Instance.Player.Status.MoveSpeed.CurrentValue;
        MoveSpeed = 5f;
    }
}
