using UnityEngine;

public class DungeonManager : MonoBehaviour 
{
    public bool isClear = false; // 클리어 여부 확인
    public GameObject SpawnerPrefab; // 생성할 스포너 프리펩
    public GameObject[] Spawns = null; // 생성된 스포너를 담을 배열 

    [SerializeField] private int CurrentDungeonIndex = 0;
    [SerializeField] private Dungeon dungeondata;

    private void Awake()
    {
        SpawnerPrefab = Resources.Load<GameObject>("Spawn");
    }
    private void Start()
    {
        dungeondata = Dungeondata.Instance.dungeon[CurrentDungeonIndex];
        CreatSpawner();
    }

    private void CreatSpawner()
    {
        for (int i = 0; i < dungeondata.Spawner.Length; i++)
        {
            GameObject newSpawner = Instantiate(SpawnerPrefab);
            //newSpawner.GetComponent<SpawnSystem>().spawnData = Spawndata.Instance.spawn[0];
            //스폰시스템 쪽에 겟데이터 함수를 만들고, 이 함수에서 
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

