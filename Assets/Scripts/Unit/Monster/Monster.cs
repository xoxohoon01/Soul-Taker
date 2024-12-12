using UnityEngine;
using DataTable;
using UnityEngine.AI;
using System.Collections;

public class Monster : MonoBehaviour, IDamageable
{
    public MonsterData data;
    public MonsterStatus status;
    public MonsterStateMachine stateMachine;

    public Animator animator;
    public NavMeshAgent agent;
    public LayerMask obstacleMask;
    public Collider myCollider;

    //MonsterData의 스킬 리스트의 index
    public int skillIndex;
    public float maxHP;

    protected void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<MonsterStatus>();
        myCollider = GetComponent<Collider>();
    }

    protected void Start()
    {
        //Test
        data = DataManager.Instance.Monster.GetMonster(101);

        if (data != null) InitializeStatus();
        maxHP = status.HP.CurrentValue;

        animator = GetComponentInChildren<Animator>();
        stateMachine = new MonsterStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    protected void Update()
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

    public void CreateSkill(int skillID, float time)
    {
        Skill skill = Instantiate(Resources.Load<GameObject>("Skill"), transform.position, Quaternion.Euler(transform.eulerAngles)).GetComponent<Skill>();
        skill.Initialize(skillID, gameObject, status.Damage.GetValue(), time);
    }

    public virtual void SelectSkillIndex()
    {
        // Test : 스킬 인덱스로 해당 스킬 애니메이션 적용
        // skillIndex로 SkillID를 얻어 SkillData 가져와 Skill에 적용
        skillIndex = Random.Range(0, data.skillList.Count);
    }

    public virtual void OnDeath()
    {
        //DungeonManager.Instance.MonsterDieCount();
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        for (int i = 0; i < 3; i++)
        {
            //ItemData dropItem = DataManager.Instance.Item.GetItemData(data.dropItems[i]);
            //if (Random.Range(0, 100f) > dropItem.dropProbability) continue;
            //GameObject dropPrefab = Resources.Load<GameObject>($"Item/{dropItem.prefabName}");
            GameObject dropPrefab = Resources.Load<GameObject>("Item/TestDropItem");
            GameObject dropItem = Instantiate(dropPrefab, transform.position, Quaternion.identity);
            dropItem.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f + Random.onUnitSphere, ForceMode.Impulse);
            yield return wait;
        }
        stateMachine.Monster.gameObject.SetActive(false);
    }

    WaitForSeconds wait = new WaitForSeconds(1f);

    public void TakeDamage(float damage)
    {
        stateMachine.IsAttacked = true;
        status.HP.CurrentValue -= damage;
    }
}