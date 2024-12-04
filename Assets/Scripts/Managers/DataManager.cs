using System.Collections.Generic;
using System.IO;
using DataTable;
using Newtonsoft.Json;
using UGS;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public CharacterDataManager Character;
    public ItemDataManager Item;
    public QuestDataManager Quest;
    public DungeonDataManager Dungeon;
    public SpawnerDataManager Spawner;
    public MonsterDataManager Monster;

    public void Initialize()
    {
        UnityGoogleSheet.LoadAllData();
        Character = new CharacterDataManager();
        Item = new ItemDataManager();
        Quest = new QuestDataManager();
        Dungeon = new DungeonDataManager();
        Spawner = new SpawnerDataManager();
        Monster = new MonsterDataManager();
    }
}
