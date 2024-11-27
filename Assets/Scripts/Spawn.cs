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

