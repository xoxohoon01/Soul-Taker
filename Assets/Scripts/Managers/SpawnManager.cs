using System;
using UnityEngine;

public class SpawnManger : MonoSingleton<SpawnManger>
{
    public Spawn spawn;
    private void TestData()
    {
        // 테스트 
        // 차후 제이슨 데이터로 로드 
        spawn = new Spawn
        {

            ID = 1,
            DungeonID = 101,
            SpawnPosition = new Vector3(3, 0, 5),
            MonsterID = 001,
            SpawnCount = 5,
            MonsterLevel = 10

        };
    }
}

