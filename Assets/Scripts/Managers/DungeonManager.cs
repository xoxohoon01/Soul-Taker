using DataTable;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isClear = false; // 클리어 여부 확인
    public GameObject SpawnerPrefab; // 생성할 스포너 프리펩
    public GameObject[] Spawns = null; // 생성된 스포너를 담을 배열 

    private void Awake()
    {
        SpawnerPrefab = Resources.Load<GameObject>("Spawn");
    }

    public void InitializeDungeon(int CurrentDungeonID)
    {
        CreatSpawner(CurrentDungeonID);
    }


    private void CreatSpawner(int CurrentDungeonID) 
    {
        for (int i = 0; i < DatabaseManager.Instance.Dungeon.GetDungeonid(CurrentDungeonID).Spawners.Count; i++)
        {
            SpawnerData spawnData = DatabaseManager.Instance.Spawner.GetSpawnerid(DatabaseManager.Instance.Dungeon.GetDungeonid(CurrentDungeonID).Spawners[i]);
            GameObject newSpawner = Instantiate(SpawnerPrefab, spawnData.SpawnPosition, Quaternion.identity);
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

