using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; }
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

    public MonsterStateMachine(Monster monster)
    {
        Monster = monster;
        Target = GameObject.FindGameObjectWithTag("Player");
        
        IdleState = new MonsterIdleState(this);
        WanderState = new MonsterWanderState(this);
        ChaseState = new MonsterChaseState(this);
        AttackState = new MonsterAttackState(this);
        DeadState = new MonsterDeadState(this);

        MoveSpeed = monster.status.MoveSpeed.GetValue();
        AttackSpeed = monster.status.AttackSpeed.GetValue();
        MinWanderDistance = monster.monsterData.minWanderDistance;
        MaxWanderDistance = monster.monsterData.maxWanderDistance;
        WanderRate = monster.monsterData.wanderRate;
        DetectRange = monster.monsterData.detectRange;
        AttackRange = monster.monsterData.attackRange;
        FieldOfView = monster.monsterData.fieldOfView;
    }
}
