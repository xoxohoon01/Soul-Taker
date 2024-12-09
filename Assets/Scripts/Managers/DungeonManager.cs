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
    public List<RoomCollider> roomColliders;

    [SerializeField] private int roomMonsterCount;
    [SerializeField] private int currentRoomID;
    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
        roomColliders = FindObjectsOfType<RoomCollider>().ToList(); // 위치 안 될 수도 있어서 체크해보자. 
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
            RoomClear(); // 콜라이더 삭제

            if (spawns.All(spawner => spawner.GetIsClear()))
            {
                DungeonClear(); // 클리어 UI 표시
            }
        }
    }
    public void EnterDungeon(int currentDungeonID)
    {
        CreateSpawner(currentDungeonID);
        PlayerManager.Instance.SpawnPlayer(new Vector3(0, 1, 0));
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
        foreach (var collider in roomColliders) 
        {
            if (collider.GetComponent<RoomCollider>().GetRoomColliderID() == currentRoomID)
            {
                collider.DestroyObject(); // 삭제 말고 콜라이더만 끄는 건? 
                roomColliders.Remove(collider);
            }
        }
        
        currentRoomID = 0;
    }
    private void DungeonClear()
    {
        isDungeonClear = true;
        UIManager.Instance.Show<UIClearDuneon>();
    }
    private void CreateSpawner(int currentDungeonID)
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

