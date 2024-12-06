using UnityEngine;
using DataTable;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterStatus status;
    public MonsterAnimationData animationData;
    public MonsterStateMachine stateMachine;
    public MonsterWeapon monsterWeapon;

    public Animator animator;
    public NavMeshAgent agent;
    public LayerMask obstacleMask;

    private void Awake()
    {
        animationData.Initialize();
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<MonsterStatus>();
    }

    private void Start()
    {
        //Test
        monsterData = DataManager.Instance.Monster.GetMonster(101);

        if (monsterData != null) InitializeStatus();
        animator = GetComponentInChildren<Animator>();
        monsterWeapon = GetComponentInChildren<MonsterWeapon>();
        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void SetMonsterData(MonsterData monsterData)
    {
        this.monsterData = monsterData;
    }

    public void InitializeStatus()
    {
        status.Level = monsterData.level;
        status.HP.originalValue = monsterData.hp + monsterData.hpPerLevel * status.Level;
        status.MP.originalValue = monsterData.mp + monsterData.mpPerLevel * status.Level;
        status.Damage.originalValue = monsterData.damage + monsterData.damagePerLevel * status.Level;
        status.Defense.originalValue = monsterData.defense + monsterData.defensePerLevel * status.Level;
        status.MoveSpeed.originalValue = monsterData.moveSpeed;
        status.AttackSpeed.originalValue = monsterData.attackSpeed;
        status.HPRegeneration.originalValue = monsterData.hpRegeneration + monsterData.hpRegenerationPerLevel * status.Level;
        status.MPRegeneration.originalValue = monsterData.mpRegeneration + monsterData.mpRegenerationPerLevel * status.Level;

        status.InitializeCurrentValue();
    }
}
