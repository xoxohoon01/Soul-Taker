using DataTable;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isDungeonClear = false; // 클리어 여부 확인
    public GameObject spawnerPrefab; // 생성할 스포너 프리펩
    public List<Spawner> spawns = new List<Spawner>();  // 생성된 스포너를 담을 배열 

    public int dungeonMonsterCount;
    private int roomMonsterCount;

    private void Awake()
    {
        spawnerPrefab = Resources.Load<GameObject>("Spawn");
    }
    private void Update()
    {
        if (roomMonsterCount <= 0 && spawns.Count == 0)
        {
            DungeonClear();
        }
    }
    public int RoomMonsterCount(int spawnerMonsterCount)
    {
        roomMonsterCount += spawnerMonsterCount;
        Debug.Log(roomMonsterCount); // 잘 나옴 
        return roomMonsterCount;
    }
    public void MonsterDieCount() // 몬스터 컨트롤러에서 참조할 예정 
    {
        roomMonsterCount--;
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

        if (roomMonsterCount <= 0)
        {
            ClearRoom(currentRoomID);
        }
    } // 몬스터 생성 
    public void ClearRoom(int currentRoomID)
    {
        Debug.Log(currentRoomID + "번 룸을 클리어 했습니다.");

        foreach (var spawner in spawns)
        {
            if (spawner.GetRoomId() == currentRoomID)
            {
                spawner.DestroyObject();
                // 룸 트리거도 없애야 될까? 
            }
        }

        // currentRoomID에 맞는 콜라이더를 제거하거나 길 생성. 
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

    private void DungeonExit()
    {

    }

}

