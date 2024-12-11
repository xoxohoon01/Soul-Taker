using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; }
    public GameObject Target { get; private set; }
    public MonsterIdleState IdleState { get; }
    public MonsterWanderState WanderState { get; }
    public MonsterChaseState ChaseState { get; }
    public MonsterWaitingAttackState WaitingAttackState { get; }
    public MonsterAttackState AttackState { get; }
    public MonsterDeadState DeadState { get; }
    public bool IsAttacked { get; set; } = false;
    public bool IsAttacking { get; set; } = false;

    public MonsterStateMachine(Monster monster)
    {
        Monster = monster;
        Target = GameObject.FindGameObjectWithTag("Player");
        
        IdleState = new MonsterIdleState(this);
        WanderState = new MonsterWanderState(this);
        ChaseState = new MonsterChaseState(this);
        WaitingAttackState = new MonsterWaitingAttackState(this);
        AttackState = new MonsterAttackState(this);
        DeadState = new MonsterDeadState(this);
    }
}
