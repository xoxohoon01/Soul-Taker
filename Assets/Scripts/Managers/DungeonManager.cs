using DataTable;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isDungeonClear = false; 
    public GameObject spawnerPrefab; 
    public List<Spawner> spawns = new List<Spawner>();   
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

        // 콜라이더를 배열로 가지고 있는 룸 트리거를 넘겨준다 
    } 
    public void RoomClear()
    {
        foreach (var roomcolliders in roomColliders) 
        {
            if (roomcolliders.GetComponent<RoomCollider>().GetRoomColliderID() == currentRoomID)
            {
                roomcolliders.DestroyObject(); // 삭제 말고 콜라이더만 끄는 건? 
            }
        }
        
        currentRoomID = 0;
    }
    private void DungeonClear()
    {
        isDungeonClear = true;
        UIManager.Instance.Show<UIClearDuneon>();
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

