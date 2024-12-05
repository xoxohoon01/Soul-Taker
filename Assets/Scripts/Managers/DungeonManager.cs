using DataTable;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isDungeonClear = false; // 클리어 여부 확인
    public GameObject spawnerPrefab; // 생성할 스포너 프리펩
    public List<Spawner> spawns = new List<Spawner>();  // 생성된 스포너를 담을 배열 
    public RoomTrigger[] roomTriggers;

    private int roomMonsterCount; 

    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
        roomTriggers[] = FindAnyObjectByType<RoomTrigger>();
    }
    private void Update()
    {
        if (roomMonsterCount <= 0 && spawns.Count == 0)
        {
            DungeonClear();
        }

        if (roomMonsterCount <= 0)
        {
            RoomClear();
        }

        // DIE 카운트에서 해준다 
    }
    public int RoomMonsterCount(int spawnerMonsterCount)
    {
        roomMonsterCount += spawnerMonsterCount;
        Debug.Log(roomMonsterCount); // 잘 나옴 

        return roomMonsterCount;
    }
    public void MonsterDieCount() 
    {
        roomMonsterCount--;

        if (roomMonsterCount <= 0 && spawns.Count == 0)
        {
            DungeonClear();
            return;
        }

        if (roomMonsterCount <= 0)
        {
            RoomClear();
            return;
        }
    }
    public void EnterDungeon(int currentDungeonID)
    {
        CreatSpawner(currentDungeonID);
    }
    public void RoomEnter(int currentRoomID)
    {
        foreach (var spawner in spawns)
        {
            if (spawner.GetRoomId() == currentRoomID)
            {
                spawner.CreatMonster(); 
            }
        }

    } // 몬스터 생성 
    public void RoomClear()
    {
        Debug.Log("룸을 클리어 했습니다.");

        //foreach (var spawner in spawns) // isSpawn 불값 넘겨줘서 관리 
        //{
        //    if (spawner.GetRoomId() == currentRoomID)
        //    {
        //        spawner.DestroyObject();
        //        // 룸 트리거도 없애야 될까? 
        //    }
        //}

        // 현재 룸 아이디 알아야 됨

        // 룸 트리거 가지고 있기 

        //currentRoomID에 맞는 콜라이더를 제거하거나 길 생성. 
        //currentRoomID = 0;

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
    private void DungeonExit()
    {

    }

}

