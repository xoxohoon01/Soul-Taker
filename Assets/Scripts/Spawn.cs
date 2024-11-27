using UnityEngine;

[System.Serializable]   
public class Spawn
{
    public int ID; // 스포너 ID 
    public Vector3 SpawnPosition; // 스포너 위치  
    public int MonsterID; // 생성할 몬스터
    public GameObject MonsterTestprefab; // 테스트 프리펩 
    public int SpawnCount; // 생성할 몬스터 개수 
    public int MonsterLevel; // 생성할 몬스터 레벨 
}

