using UnityEngine;
using DataTable;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterData data;
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
        data = DataManager.Instance.Monster.GetMonster(101);

        if (data != null) InitializeStatus();
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
        data = monsterData;
    }

    public void InitializeStatus()
    {
        status.Level = data.level;
        status.HP.originalValue = data.hp + data.hpPerLevel * status.Level;
        status.MP.originalValue = data.mp + data.mpPerLevel * status.Level;
        status.Damage.originalValue = data.damage + data.damagePerLevel * status.Level;
        status.Defense.originalValue = data.defense + data.defensePerLevel * status.Level;
        status.MoveSpeed.originalValue = data.moveSpeed;
        status.AttackSpeed.originalValue = data.attackSpeed;
        status.HPRegeneration.originalValue = data.hpRegeneration + data.hpRegenerationPerLevel * status.Level;
        status.MPRegeneration.originalValue = data.mpRegeneration + data.mpRegenerationPerLevel * status.Level;

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
        //skillIndex = Random.Range(0, data.skillList.Count);
        skillIndex = 3;
    }
}