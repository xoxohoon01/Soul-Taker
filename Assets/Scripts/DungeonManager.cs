using UnityEngine;

public class DungeonManager : MonoSingleton<DungeonManager>
{
    public bool isClear = false; // 클리어 여부 확인
    public GameObject[] Spawns = null; // 생성할 스포너 배열로 저장

    private void Start()
    {
        // 현재 던전 데이터 초기화
        // 스포너 초기화

        // DungeonID에 맞는 스포너를 배열로 저장해서 넣어야 함 
        //Spawns = new GameObject[SpawnManger.Instance.spawn.DungeonID];

        for (int i = 0; i < SpawnManger.Instance.spawn.SpawnCount; i++)
        {
            GameObject obj = Instantiate(SpawnManger.Instance.spawn.MonsterTestprefab);
            Spawns[i] = obj;
        }
    }

    private void DungeonEnter() 
    {
        // 각 구역마다 스포너 초기화
        // 관련 퀘스트 상태 '진행중'으로 변경
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

