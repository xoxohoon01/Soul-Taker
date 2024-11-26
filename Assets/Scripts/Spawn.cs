using UnityEngine;

[System.Serializable]   
public class Spawn
{
    public int ID; // 스포너 ID 
    public int DungeonID; // 생성 되어야 할 던전
    public Vector3 SpawnPosition; // 스포너 위치  
    public int MonsterID; // 생성할 몬스터
    public GameObject MonsterTestprefab; // 테스트 프리펩 (나중에 삭제하고 ID로만 씁니다) 
    public int SpawnCount; // 생성할 몬스터 개수 
    public int MonsterLevel; // 생성할 몬스터 레벨 
}

[System.Serializable]
public class Spawndata
{
    // 맵에서 여러 개의 스포너를 가지고 있어야 되기 때문에 배열로 저장 
    public Spawn[] spawns;
}

