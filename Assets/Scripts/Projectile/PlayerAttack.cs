using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // 오브젝트를 생성한 개체
    public GameObject sender;

    #region sender에서 초기화할 것들

    // 특징
    public Vector3 size = new Vector3(1, 1, 1);
    public Vector3 offset = Vector3.zero;
    public Vector3 moveVector = Vector3.zero;
    public float lifeTime;
    public float multiHitDelay;

    // 데미지
    public float damage;
    public float critChance;
    public float critDamage;

    #endregion

    List<GameObject> hitObjects = new List<GameObject>(); // 이미 타격한 오브젝트들

    private void Start()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        transform.localScale = size;
        transform.position = 
            transform.position + 
            (transform.right * offset.x) + 
            (transform.up * offset.y) + 
            (transform.forward * offset.z) + 
            (Vector3.up * (size.y / 2.0f));
    }

    private void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

        Collider[] colliders = Physics.OverlapBox(transform.position, size, Quaternion.Euler(transform.eulerAngles));

        foreach (Collider collider in colliders)
        {
            if (collider.tag != sender.tag && !hitObjects.Contains(collider.gameObject) && collider.GetComponent<Status>() != null)
            {
                Status status = collider.GetComponent<Status>();
                // 크리티컬 실패시 치명타데미지 계수 1로 조정
                if (Random.Range(0.0f, 100.0f) > critChance)
                {
                    critDamage = 1;
                }
                status.HP.CurrentValue -= Mathf.Max((damage - status.Defense.GetValue()) * critDamage * Random.Range(0.9f, 1.1f), damage * 0.2f);
                hitObjects.Add(collider.gameObject);
                if (multiHitDelay != 0)
                    StartCoroutine(RestoreMultiHit(collider.gameObject, multiHitDelay));
            }
        }
    }

    private IEnumerator RestoreMultiHit(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);
        hitObjects.Remove(target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
