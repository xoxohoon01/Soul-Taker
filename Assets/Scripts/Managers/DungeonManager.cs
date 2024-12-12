using DataTable;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isDungeonClear = false;
    private int _currentDungeonID;
    public GameObject spawnerPrefab;
    public List<Spawner> spawns = new List<Spawner>();
    public List<RoomCollider> roomColliders;

    [SerializeField] private int roomMonsterCount;
    [SerializeField] private int currentRoomID;
    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
        roomColliders = FindObjectsOfType<RoomCollider>().ToList();
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
        _currentDungeonID = currentDungeonID;

        CreateSpawner(_currentDungeonID);
        PlayerManager.Instance.SpawnPlayer(new Vector3(0, 1, 0));

        Camera.main.transform.SetParent(PlayerManager.Instance.player.transform);
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
        foreach (var collider in roomColliders)
        {
            if (collider.GetComponent<RoomCollider>().GetRoomColliderID() == currentRoomID)
            {
                collider.DestroyObject(); 
                roomColliders.Remove(collider);
            }
        }

        currentRoomID = 0;
    }
    private void DungeonClear()
    {
        isDungeonClear = true;

        GameObject rewardPrefab = Resources.Load<GameObject>("Reward");
        ObjectData rewardData = DataManager.Instance.Object.GetObjectid(DataManager.Instance.Dungeon.GetDungeonid(_currentDungeonID).reward);

        if (rewardPrefab != null)
        {
            GameObject goReward = Instantiate(
                rewardPrefab,
                rewardData.postion,
                Quaternion.identity
            );

            RewardBox rewardScript = goReward.GetComponent<RewardBox>();

            if (rewardScript != null)
            {
                rewardScript.Initalize(rewardData.ID);
            }
        }
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

