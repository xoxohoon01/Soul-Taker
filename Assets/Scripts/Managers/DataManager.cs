using System.IO;
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
    public SkillDataManager Skill;
    public ObjectDataManager Object;

    public void Initialize()
    {
        UnityGoogleSheet.LoadAllData();
        Character = new CharacterDataManager();
        Item = new ItemDataManager();
        Quest = new QuestDataManager();
        Dungeon = new DungeonDataManager();
        Spawner = new SpawnerDataManager();
        Monster = new MonsterDataManager();
        Skill = new SkillDataManager();
        Object = new ObjectDataManager();
    }
}
