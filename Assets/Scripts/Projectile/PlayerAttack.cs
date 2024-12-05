using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    

    public Rigidbody rb;

    #region sender에서 초기화할 것들

    // 특징
    public Vector3 size = new Vector3(1, 1, 1);
    public Vector3 offset = Vector3.zero;
    public Vector3 moveVector = Vector3.zero;
    public float lifeTime;
    public int maxMultiHit;
    public float multiHitDelay;

    // 데미지
    public float damage;
    public float critChance;
    public float critDamage;

    #endregion

    private GameObject sender; // 오브젝트를 생성한 개체
    private SkillData currentSkill; // 스킬데이터
    private Dictionary<GameObject, HitInfo> hitInfoMap = new Dictionary<GameObject, HitInfo>(); // 타격 여부 및 타격 횟수 저장

    private class HitInfo
    {
        public int hitCount; // 타격 횟수
        public bool canHit; // 타격 가능 여부
    }

    public void Initialize(int id, GameObject sender)
    {
        currentSkill = DataManager.Instance.Skill.GetSkill(id);

        this.sender = sender;

        lifeTime = currentSkill.lifeTime;
        transform.localScale = currentSkill.size;
        transform.position =
            transform.position +
            (transform.right * currentSkill.offset.x) +
            (transform.up * currentSkill.offset.y) +
            (transform.forward * currentSkill.offset.z) +
            (Vector3.up * (currentSkill.size.y / 2.0f));
        rb.velocity = transform.forward * currentSkill.speed;
    }

    private void Attack()
    {
        // OverlapBox로 충돌 감지 후, 가까운 순으로 정렬
        Collider[] colliders = Physics.OverlapBox(transform.position, size, Quaternion.Euler(transform.eulerAngles))
            .OrderBy(target => Vector3.Distance(transform.position, target.transform.position))
            .ToArray();

        foreach (Collider collider in colliders)
        {
            // SkillData의 targetCount값에 따라 타격할 적(hitInfoMap)의 갯수 결정
            if (hitInfoMap.Count < currentSkill.targetCount)
            {
                // 적인지 판단 후, hitInfoMap과 canHit를 반환
                if (collider.tag != sender.tag &&
                    !hitInfoMap.TryGetValue(collider.gameObject, out HitInfo info) &&
                    TryGetComponent(out Status status))
                {
                    // 적의 hitCount와 canHit 값에 따라 타격 가능한 상태인지 판단
                    if (hitInfoMap[collider.gameObject].hitCount < currentSkill.maxHitCount && hitInfoMap[collider.gameObject].canHit)
                    {
                        #region 공격 로직
                        if (Random.Range(0.0f, 100.0f) > critChance) // 크리티컬 실패시 치명타데미지 계수 1로 조정
                        {
                            critDamage = 1;
                        }
                        status.HP.CurrentValue -= Mathf.Max((damage - status.Defense.GetValue()) * critDamage * Random.Range(0.9f, 1.1f), damage * 0.2f);
                        #endregion

                        hitInfoMap[collider.gameObject].canHit = false;
                        hitInfoMap[collider.gameObject].hitCount += 1;

                        if (currentSkill.hitDelay != 0) // SkillData의 hitDelay가 0일 경우 다단히트 불가
                            StartCoroutine(CoRestoreMultiHit(collider.gameObject, currentSkill.hitDelay));
                        
                    }
                }
            }
            else
            {
                return;
            }
        }

        
    }

    private IEnumerator CoRestoreMultiHit(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);
        hitInfoMap[target].canHit = true;
    }

    private void CheckLifeTime()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        CheckLifeTime();
        Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
