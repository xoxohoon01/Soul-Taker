using DataTable;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isClear = false; // 클리어 여부 확인
    public GameObject spawnerPrefab; // 생성할 스포너 프리펩
    public GameObject[] spawns = null; // 생성된 스포너를 담을 배열 

    // 스포너를 관리할 변수 만들기 (배열... 딕셔너리... 리스트...) 

    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
    }

    public void InitializeDungeon(int CurrentDungeonID)
    {
        Debug.Log("실행됨");
        CreatSpawner(CurrentDungeonID);
    }


    private void CreatSpawner(int CurrentDungeonID) 
    {
        for (int i = 0; i < DataManager.Instance.Dungeon.GetDungeonid(CurrentDungeonID).spawners.Count; i++)
        {
            SpawnerData spawnData = DataManager.Instance.Spawner.GetSpawnerid(DataManager.Instance.Dungeon.GetDungeonid(CurrentDungeonID).spawners[i]);
            GameObject newSpawner = Instantiate(spawnerPrefab, spawnData.position, Quaternion.identity);
            newSpawner.GetComponent<SpawnSystem>().InitializeObjectPool(spawnData); // 데이터 전달
        }
    }

    private void DungeonClear()
    {
        /* if */
        // 보물 상자와 상호작용 했을 때 
        // monster 태그의 오브젝트가 현재 씬에서 존재하지 않을 때
        {
            isClear = true;
        }

        DungeonExit();
    }

    private void DungeonExit()
    {

    }

}

