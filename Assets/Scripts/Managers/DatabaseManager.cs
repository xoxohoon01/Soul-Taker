using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using TMPro;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    public List<Character> CharacterDB;
    public List<ItemData> ItemDB;
    public List<MonsterData> MonsterDB;

    public void LoadDatabase()
    {
        // 아이템 데이터베이스
        DirectoryInfo itemDirectoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Items");
        if (itemDirectoryInfo.GetFiles().Length > 0)
        {
            for (int i = 0; i < itemDirectoryInfo.GetFiles().Length; i++)
            {
                string data = File.ReadAllText(Application.persistentDataPath + $"/Items/{itemDirectoryInfo.GetFiles()[i].Name}");
                ItemData newItem = JsonUtility.FromJson<ItemData>(data);
                ItemDB.Add(newItem);
            }
        }
        else
        {
            ItemDB = new List<ItemData>();
            ItemData newItem = new ItemData();
            newItem.displayName = "Test";
            ItemDB.Add(newItem);
        }

        // 몬스터 데이터베이스
        DirectoryInfo monsterDirectoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Monsters");
        if (monsterDirectoryInfo.GetFiles().Length > 0)
        {
            for (int i = 0; i < monsterDirectoryInfo.GetFiles().Length; i++)
            {
                string data = File.ReadAllText(Application.persistentDataPath + $"/Monsters/{monsterDirectoryInfo.GetFiles()[i].Name}");
                MonsterData newMonster = JsonUtility.FromJson<MonsterData>(data);
                MonsterDB.Add(newMonster);
            }
        }
        else
        {
            MonsterDB = new List<MonsterData>();
            MonsterData newMonster = new MonsterData();
            newMonster.Name = "Test";
            MonsterDB.Add(newMonster);
        }
    }

    public void SaveDatabase()
    {
        string data = JsonUtility.ToJson(ItemDB.ToArray(), true);
        File.WriteAllText(Application.persistentDataPath + "/Items.json", data);
    }

    private new void Awake()
    {
        base.Awake();
        MonsterDB = new List<MonsterData>();
        ItemDB = new List<ItemData>();
        MonsterDB = new List<MonsterData>();
        LoadDatabase();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SaveDatabase();
    }
}