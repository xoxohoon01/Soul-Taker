using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger Instance { get; private set; }
    public Spawndata spawndata;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
            return;
        }

        TestData();
    }

    private void TestData()
    {
        // 테스트용, 나중에 제이슨 파일에서 로드해야 됩니다. 
        spawndata = new Spawndata();

        spawndata.spawns = new Spawn[]
        {
            new Spawn
            {
                ID = 1,
                DungeonID = 101,
                SpawnPosition = new Vector3(0, 0, 0),
                MonsterID = 001,
                SpawnCount = 5,
                MonsterLevel = 10
            }
        };
           
    }
}

