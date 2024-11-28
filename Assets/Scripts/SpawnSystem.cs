using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Tooltip("스폰 위치 배열")]
    [SerializeField] private Vector3[] spawnPositions; // 임시, 생성 규칙 그리드로 변경 예정 
    [Tooltip("풀링된 오브젝트")]
    [SerializeField] private GameObject[] objectPool;

    public Spawn spawnData;
    
    private void Awake()
    {
        //objectPool = new GameObject[Spawndata.Instance.spawn.SpawnCount];

        //for (int i = 0; i < Spawndata.Instance.spawn.SpawnCount; i++)
        //{
        //    GameObject obj = Instantiate(Spawndata.Instance.spawn.MonsterTestprefab);
        //    obj.SetActive(false); 
        //    obj.transform.SetParent(this.transform); 
        //    objectPool[i] = obj;
        //}
    }

    private void Start()
    {
        // 일정 반경 안에서 플레이어를 찾으면 활성화
        // 콜라이더를 설정해서 enter 콜라이더로 활성화
        // 또는 플레이어가 방에 입장했을 때 onEnter?Invoke 활성화
        //Spawn();
    }

    //public void Spawn()
    //{
    //    for (int i = 0; i < Spawndata.Instance.spawn.SpawnCount; i++)
    //    {
    //        if (i >= spawnPositions.Length)
    //            break;

    //        GameObject obj = objectPool[i];
    //        if (!obj.activeInHierarchy)
    //        {
    //            obj.transform.localPosition = spawnPositions[i]; 
    //            obj.SetActive(true); 
    //        }
    //    }
    //}

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
