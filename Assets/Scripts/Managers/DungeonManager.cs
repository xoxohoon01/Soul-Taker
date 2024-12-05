using DataTable;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isDungeonClear = false; // 클리어 여부 확인
    public GameObject spawnerPrefab; // 생성할 스포너 프리펩
    public List<Spawner> spawns = new List<Spawner>();  // 생성된 스포너를 담을 배열 
    public RoomCollider[] roomColliders;

    private int roomMonsterCount;
    private int currentRoomID;

    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
        roomColliders = FindObjectsOfType<RoomCollider>(); // 위치 안 될 수도 있어서 체크해보자. 
    }
    public int RoomMonsterCount(int _spawnerMonsterCount)
    {
        roomMonsterCount += _spawnerMonsterCount;
        return roomMonsterCount;
    }
    public void MonsterDieCount() 
    {
        roomMonsterCount--;

        if (roomMonsterCount <= 0)
        {
            RoomClear();

            if (spawns.All(spawner => spawner.GetIsClear()))
            {
                DungeonClear();
            }
        }
    }
    public void EnterDungeon(int currentDungeonID)
    {
        CreatSpawner(currentDungeonID);
    }
    public void RoomEnter(int _currentRoomID)
    {
        currentRoomID = _currentRoomID;

        foreach (var spawner in spawns)
        {
            if (spawner.GetRoomId() == currentRoomID)
            {
                spawner.CreatMonster(); 
            }
        }

    } 
    public void RoomClear()
    {
        foreach (var roomcolliders in roomColliders) 
        {
            if (roomcolliders.GetComponent<RoomCollider>().GetRoomColliderID() == currentRoomID)
            {
                roomcolliders.DestroyObject();
            }
        }
        
        currentRoomID = 0;
    }
    private void DungeonClear()
    {
        isDungeonClear = true;
        //UIManager.Instance.Show<UIDungeonClear>;
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
}

