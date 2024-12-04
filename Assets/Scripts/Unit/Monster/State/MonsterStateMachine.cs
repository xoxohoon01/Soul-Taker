using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public MonsterBehavior Behavior { get; }
    public GameObject Target { get; private set; }
    public MonsterIdleState IdleState { get; }
    public MonsterWanderState WanderState { get; }
    public MonsterChaseState ChaseState { get; }
    public MonsterAttackState AttackState { get; }
    public MonsterDeadState DeadState { get; }

    public float MoveSpeed { get; private set; }
    public float MinWanderDistance { get; private set; }
    public float MaxWanderDistance { get; private set; }
    public float WanderRate { get; private set; }
    public float AttackSpeed { get; private set; }
    public float DetectRange { get; private set; }
    public float AttackRange { get; private set; }
    public float FieldOfView { get; private set; }
    public bool IsAttacked { get; set; } = false;

    public MonsterStateMachine(MonsterBehavior monsterBehavior)
    {
        Behavior = monsterBehavior;
        Target = GameObject.FindGameObjectWithTag("Player");
        
        IdleState = new MonsterIdleState(this);
        WanderState = new MonsterWanderState(this);
        ChaseState = new MonsterChaseState(this);
        AttackState = new MonsterAttackState(this);
        DeadState = new MonsterDeadState(this);

        MoveSpeed = monsterBehavior.Status.MoveSpeed.GetValue();
        AttackSpeed = monsterBehavior.Status.AttackSpeed.GetValue();
        MinWanderDistance = monsterBehavior.Status.MinWanderDistance;
        MaxWanderDistance = monsterBehavior.Status.MaxWanderDistance;
        WanderRate = monsterBehavior.Status.WanderRate;
        DetectRange = monsterBehavior.Status.DetectRange;
        AttackRange = monsterBehavior.Status.AttackRange;    
        FieldOfView = monsterBehavior.Status.FieldOfView;
    }
}
