using DataTable;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isClear = false; // 클리어 여부 확인
    public GameObject spawnerPrefab; // 생성할 스포너 프리펩
    public List<Spawner> spawns = new List<Spawner>();  // 생성된 스포너를 담을 배열 

    public int dungeonMonsterCount;
    public int RoomMonsterCount;

    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
    }

    public void EnterDungeon(int currentDungeonID)
    {
        CreatSpawner(currentDungeonID);
    }

    public void EnterRoom(int currentRoomID)
    {
        foreach (var spawner in spawns)
        {
            if (spawner.GetRoomId() == currentRoomID)
            {
                spawner.CreatMonster(); 
            }
        }
    } // 몬스터 생성 
    public void ClearRoom()
    {

    }

    private void CreatSpawner(int currentDungeonID)
    {
        foreach (var spawnerID in DataManager.Instance.Dungeon.GetDungeonid(currentDungeonID).spawners)
        {
            SpawnerData spawnData = DataManager.Instance.Spawner.GetSpawnerid(spawnerID);
            GameObject newSpawnerGO = Instantiate(spawnerPrefab, spawnData.position, Quaternion.identity);

            Spawner newSpawner = newSpawnerGO.GetComponent<Spawner>();
            newSpawner.InitializeSpawner(spawnData);
            spawns.Add(newSpawner);
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

