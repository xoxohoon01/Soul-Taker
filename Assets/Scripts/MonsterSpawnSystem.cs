using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnSystem : MonoBehaviour
{

    [Tooltip("오브젝트 프리펩")]
    [SerializeField] private GameObject targetObjects;
    [Tooltip("스폰될 오브젝트의 개수")] // 풀링 개수 
    [SerializeField] private int spawnCount;
    [Tooltip("스폰 위치 배열")]
    [SerializeField] private Vector3[] spawnPositions;

    [Tooltip("풀링된 오브젝트")]
    [SerializeField] private GameObject[] objectPool;


    private void Awake()
    {
        objectPool = new GameObject[spawnCount];

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject obj = Instantiate(targetObjects);
            obj.SetActive(false); 
            obj.transform.SetParent(this.transform);
            objectPool[i] = obj;
        }
    }

    private void Start()
    {
        // 일정 반경 안에서 플레이어를 찾으면 활성화
        // 콜라이더를 설정해서 enter 콜라이더로 활성화
        // 또는 플레이어가 방에 입장했을 때 onEnter?Invoke 활성화

        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
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
