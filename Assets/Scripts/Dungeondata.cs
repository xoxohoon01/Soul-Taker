using System;
using UnityEngine;
public class Dungeondata : MonoSingleton<Dungeondata>
{
    public Dungeon[] dungeon;

    private void Awake()
    {
        TestDungeonData();
    }
    private void TestDungeonData()
    {
        dungeon = new Dungeon[]
        {
            new Dungeon
            {
            ID = 001,
            Name = "고블린 마을",
            Description = "고블린이 살고 있습니다.",
            Difficulty = 0,
            PlayerLevel = 10,
            Spawner = new int[] { 101, 102 }
            }
        };
    }
}

