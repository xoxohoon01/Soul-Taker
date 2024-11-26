using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnSystem : MonoBehaviour
{
    [Tooltip("���� ��ġ �迭")]
    [SerializeField] private Vector3[] spawnPositions; // �ӽ�, ���� ��Ģ �׸���� ���� ���� 
    [Tooltip("Ǯ���� ������Ʈ")]
    [SerializeField] private GameObject[] objectPool;

    private void Awake()
    {
        objectPool = new GameObject[SpawnManger.Instance.spawndata.spawns[0].SpawnCount];

        for (int i = 0; i < SpawnManger.Instance.spawndata.spawns[0].SpawnCount; i++)
        {
            GameObject obj = Instantiate(SpawnManger.Instance.spawndata.spawns[0].MonsterTestprefab);
            obj.SetActive(false); 
            obj.transform.SetParent(this.transform); 
            objectPool[i] = obj;
        }
    }

    private void Start()
    {
        // ���� �ݰ� �ȿ��� �÷��̾ ã���� Ȱ��ȭ
        // �ݶ��̴��� �����ؼ� enter �ݶ��̴��� Ȱ��ȭ
        // �Ǵ� �÷��̾ �濡 �������� �� onEnter?Invoke Ȱ��ȭ
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < SpawnManger.Instance.spawndata.spawns[0].SpawnCount; i++)
        {
            if (i >= spawnPositions.Length)
                break;

            GameObject obj = objectPool[i];
            if (!obj.activeInHierarchy)
            {
                obj.transform.localPosition = spawnPositions[i]; 
                obj.SetActive(true); 
            }
        }
    }

    public void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectPool)
        {
            if (obj.activeInHierarchy)
            {
                obj.SetActive(false); 
            }
        }
    }
}
