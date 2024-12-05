using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehavior : MonoBehaviour
{
    public MonsterStateMachine stateMachine;
    public MonsterAnimationData animationData;
    public NavMeshAgent agent;
    public LayerMask ObstacleMask;
    public MonsterStatus Status { get; set; }
    public Animator Animator { get; private set; }
    private void Awake()
    {
        animationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
