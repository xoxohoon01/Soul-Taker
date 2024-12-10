using UnityEngine;
using DataTable;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterStatus status;
    public MonsterStateMachine stateMachine;

    public Animator animator;
    public NavMeshAgent agent;
    public LayerMask obstacleMask;

    //MonsterData의 스킬 리스트의 index
    public int skillIndex;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<MonsterStatus>();
    }

    private void Start()
    {
        //Test
        monsterData = DataManager.Instance.Monster.GetMonster(101);

        if (monsterData != null) InitializeStatus();
        animator = GetComponentInChildren<Animator>();
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

    public void CreateSkill(int skillID)
    {
        Skill skill = Instantiate(Resources.Load<GameObject>("Skill"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<Skill>();
        skill.Initialize(skillID, gameObject, status.Damage.GetValue());
    }

    public void SelectSkillIndex()
    {
        // Test : 스킬 인덱스로 해당 스킬 애니메이션 적용
        // skillIndex로 SkillID를 얻어 SkillData 가져와 Skill에 적용
        skillIndex = Random.Range(0, 4);
    }
}