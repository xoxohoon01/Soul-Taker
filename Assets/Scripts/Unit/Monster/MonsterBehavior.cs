using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehavior : MonoBehaviour
{
    public MonsterStateMachine stateMachine;
    public MonsterAnimationData animationData;
    public Transform mainMesh;
    public NavMeshAgent agent;
    public LayerMask ObstacleMask;
    //public Health health;

    public MonsterStatus Status { get; set; }
    public Animator Animator { get; private set; }
    private void Awake()
    {
        animationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //health = GetComponent<Health>();
    }

    private void Start()
    {
        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
        //health.OnDie += OnDie;
    }

    private void Update()
    {
        stateMachine.Update();
    }

    //private void OnDie()
    //{
    //    stateMachine.ChangeState(stateMachine.DeadState);
    //}
}
