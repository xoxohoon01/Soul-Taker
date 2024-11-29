using UnityEngine;
using UnityEngine.AI;

public class MonsterBehavior : MonoBehaviour
{
    public MonsterStateMachine stateMachine;
    public MonsterAnimationData animationData;
    public Transform mainMesh;
    public NavMeshAgent agent;
    public MonsterStatus Status { get; set; }
    public Animator Animator { get; private set; }
    private void Awake()
    {
        animationData.Initialize();
        Animator = GetComponent<Animator>();
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
