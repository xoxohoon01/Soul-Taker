using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public MonsterBehavior Behavior { get; }
    public GameObject Target { get; private set; }
    public MonsterIdleState IdleState { get; }
    public MonsterPatrolState PatrolState { get; }
    public MonsterChaseState ChaseState { get; }
    public MonsterAttackState AttackState { get; }
    public MonsterDeadState DeadState { get; }

    public float MoveSpeed { get; private set; }
    public float MinPatrolDistance { get; private set; }
    public float MaxPatrolDistance { get; private set; }
    public float PatrolRate { get; private set; }
    public float AttackSpeed { get; private set; }
    public float DetectRange { get; private set; }
    public float AttackRange { get; private set; }
    public float FieldOfView { get; private set; }
    public bool IsAttacking { get; set; }

    public MonsterStateMachine(MonsterBehavior monsterBehavior)
    {
        Behavior = monsterBehavior;
        Target = GameObject.FindGameObjectWithTag("Player");
        
        IdleState = new MonsterIdleState(this);
        PatrolState = new MonsterPatrolState(this);
        ChaseState = new MonsterChaseState(this);
        AttackState = new MonsterAttackState(this);
        DeadState = new MonsterDeadState(this);

        //MoveSpeed = monsterBehavior.Status.MoveSpeed.CurrentValue;
        //AttackSpeed = monsterBehavior.Status.AttackSpeed.CurrentValue;
        //MinPatrolDistance = monsterBehavior.Status.MinPatrolDistance;
        //MaxPatrolDistance = monsterBehavior.Status.MaxPatrolDistance;
        //PatrolRate = monsterBehavior.Status.PatrolRate;
        MoveSpeed = 3f;
        AttackSpeed = 1.5f;
        MinPatrolDistance = 3f;
        MaxPatrolDistance = 10f;
        PatrolRate = 5f;
        DetectRange = monsterBehavior.Status.DetectRange;
        AttackRange = monsterBehavior.Status.AttackRange;
        FieldOfView = monsterBehavior.Status.FieldOfView;
    }
}
