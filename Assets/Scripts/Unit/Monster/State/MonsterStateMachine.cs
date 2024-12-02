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

    public float MoveSpeed { get; private set; }
    public float AttackSpeed { get; private set; }
    public float DetectRange { get; private set; }
    public float AttackRange { get; private set; }
    public float FieldOfView { get; private set; }
    public bool IsAttacking { get; set; }

    public MonsterStateMachine(MonsterBehavior monsterBehavior)
    {
        Behavior = monsterBehavior;
        Target = CharacterManager.Instance.Player.gameObject;

        IdleState = new MonsterIdleState(this);
        PatrolState = new MonsterPatrolState(this);
        ChaseState = new MonsterChaseState(this);
        AttackState = new MonsterAttackState(this);

        MoveSpeed = monsterBehavior.Status.MoveSpeed.CurrentValue;
        AttackSpeed = monsterBehavior.Status.AttackSpeed.CurrentValue;
        DetectRange = monsterBehavior.Status.DetectRange;
        AttackRange = monsterBehavior.Status.AttackRange;
        FieldOfView = monsterBehavior.Status.FieldOfView;
    }
}
