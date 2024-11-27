using System;
using UnityEngine;

public class Spawndata: MonoSingleton<Spawndata>
{
    public Spawn[] spawn;
    public GameObject GameObject; // 임시 몬스터 프리펩
    public GameObject GameObject2;
    private void TestSpawnData()
    {
        spawn = new Spawn[]
        {
            new Spawn
            {
            ID = 101,
            SpawnPosition = new Vector3(3, 0, 5),
            MonsterID = 201,
            MonsterTestprefab = GameObject,
            SpawnCount = 5,
            MonsterLevel = 10
            },

            new Spawn 
            { 
            ID = 102,
            SpawnPosition = new Vector3(3, 0, 5),
            MonsterID = 202,
            MonsterTestprefab = GameObject2,
            SpawnCount = 7,
            MonsterLevel = 20
            }
        };
    }
}

