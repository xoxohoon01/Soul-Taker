using System.Collections.Generic;
using System.IO;
using DataTable;
using Newtonsoft.Json;
using UGS;
using UnityEngine;

//DataManager 이름 변경하기
public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    // 클래스명 변경, MonoSingleton -> Mono 떼세요;
    public CharacterDataManager Character;
    public ItemDataManager Item;
    public QuestDataManager Quest;
    public DungeonDataManager Dungeon;
    public SpawnerDataManager Spawner;

    public string savePath = Application.persistentDataPath;

    public void Initialize()
    {
        UnityGoogleSheet.LoadAllData();
        Item = new ItemDataManager();
        Quest = new QuestDataManager();
        Dungeon = new DungeonDataManager();
        Spawner = new SpawnerDataManager();
    }
    
    //클래스 따로 만들어서 옮기기 //DatabaseManager
    public void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath + $"/{typeof(T)}.txt", json);
    }

    public T LoadData<T>()
    {
        string loadJson = File.ReadAllText(savePath + $"/{typeof(T)}.txt");
        return JsonUtility.FromJson<T>(loadJson); 
    }
    
    public List<T> LoadDataList<T>()
    {
        string loadJson = File.ReadAllText(savePath + $"/{typeof(T)}.txt");
        return JsonConvert.DeserializeObject<List<T>>(loadJson);
    }
    
    /*
    public List<ItemInstance> Parse(string FileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(FileName);
        if (jsonFile == null)
        {
            Debug.LogError($"파일 {FileName}을 찾을 수 없습니다.");
            return null;
        }
        ItemJSON item = JsonUtility.FromJson<ItemJSON>(jsonFile.text); // 역직렬화
        return item.items;
    }*/
}
