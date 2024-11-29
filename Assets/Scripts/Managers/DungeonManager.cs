using Database;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isClear = false; // 클리어 여부 확인
    public GameObject SpawnerPrefab; // 생성할 스포너 프리펩
    public GameObject[] Spawns = null; // 생성된 스포너를 담을 배열 

    //[SerializeField] private int CurrentDungeonID = 2001;

    private Dungeon Dungeon;
    private void Awake()
    {
        SpawnerPrefab = Resources.Load<GameObject>("Spawn");
    }
    //private void Start()
    //{
    //    int currentIndex = 0;

    //    for (int i = 0; i < Dungeons.DungeonsList.Count; i++)
    //    {
    //        if (Dungeons.DungeonsList[i].ID == CurrentDungeonID)
    //        {
    //            currentIndex = i;
    //            break;
    //        }
    //    }

    //    Dungeon = DatabaseManager.Instance.Parse<Dungeon>(Dungeons.DungeonsList[currentIndex]);
    //    CreatSpawner();
    //}

    public void InitializeDungeon(int CurrentDungeonID)
    {
        int currentIndex = 0;

        for (int i = 0; i < Dungeons.DungeonsList.Count; i++)
        {
            if (Dungeons.DungeonsList[i].ID == CurrentDungeonID)
            {
                currentIndex = i;
                break;
            }
        }

        Dungeon = DatabaseManager.Instance.Parse<Dungeon>(Dungeons.DungeonsList[currentIndex]);
        CreatSpawner();
    }


    private void CreatSpawner() // 스포너 생성
    {

        List<int> matchingIndex = new List<int>();

        for (int i = 0; i < Dungeon.Spawners.Count; i++)
        {
            int spawnerID = Dungeon.Spawners[i];
            Debug.Log(spawnerID); // 101, 102 

            for (int j = 0; j < Spawners.SpawnersList.Count; j++)
            {
                if (Spawners.SpawnersList[j].ID == spawnerID)
                {
                    matchingIndex.Add(j);
                    Debug.Log(matchingIndex.Count); // 여기까지 잘 됨 
                }
            }
        }

        if (matchingIndex.Count > 0)
        {
            foreach (int index in matchingIndex)
            {
               
                Spawn spawnData = DatabaseManager.Instance.Parse<Spawn>(Spawners.SpawnersList[index]);

                GameObject newSpawner = Instantiate(SpawnerPrefab, spawnData.SpawnPosition, Quaternion.identity);
                newSpawner.GetComponent<SpawnSystem>().InitializeObjectPool(spawnData); // 데이터 전달
            }
        }
        else
        {
            Debug.Log("매칭되는 스포너가 없습니다.");
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

