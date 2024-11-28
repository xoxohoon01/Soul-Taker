using Database;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Dungeondata : MonoSingleton<Dungeondata>
{
    public Dungeon DungeonInitialize(int CurrentDungeonIndex)
    {
        Dungeon dungeon = new Dungeon
        {
            ID = Dungeons.DungeonsList[CurrentDungeonIndex].ID,
            Name = Dungeons.DungeonsList[CurrentDungeonIndex].Name,
            Description = Dungeons.DungeonsList[CurrentDungeonIndex].Description,
            Difficulty = Dungeons.DungeonsList[CurrentDungeonIndex].Difficulty,
            PlayerLevel = Dungeons.DungeonsList[CurrentDungeonIndex].PlayerLevel,
            Spawners = new List<int>(Dungeons.DungeonsList[CurrentDungeonIndex].Spawner)
        };

        return dungeon;
    }
}

