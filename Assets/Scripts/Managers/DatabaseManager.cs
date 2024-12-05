using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    public ItemInstanceData items;
    public string fileName;

    [ContextMenu("To Json Data")]
    private void SaveItemData()
    {
        string jsonString = JsonUtility.ToJson(items, true);
        string path = Path.Combine(Application.dataPath, $"{fileName}.json");
        File.WriteAllText(path, jsonString);
        ItemManager.Instance.Initialize(LoadItemData());
    }
    
    private ItemInstanceData LoadItemData()
    {
        string path = Path.Combine(Application.dataPath, $"{fileName}.json");
        string jsonString = File.ReadAllText(path);
        return JsonUtility.FromJson<ItemInstanceData>(jsonString);
    }
    //---------------------------------------------------위에 함수 두개와 변수 두개 인스펙터 에서 아이템 추가하는 용도
    public void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + $"/{typeof(T)}.txt", json);
    }

    public T LoadData<T>()
    { 
        string filePath = Application.persistentDataPath + $"/{typeof(T)}.txt";
        if (!File.Exists(filePath))
        {
            return default;
        }
        
        string loadJson = File.ReadAllText(Application.persistentDataPath + $"/{typeof(T)}.txt");
        return JsonUtility.FromJson<T>(loadJson);
    }

    public List<T> LoadDataList<T>()
    {
        string filePath = Application.persistentDataPath + $"/{typeof(T)}.txt";
        Debug.Log(filePath);
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }
        
        string loadJson = File.ReadAllText(Application.persistentDataPath + $"/{typeof(T)}.txt");
        return JsonConvert.DeserializeObject<List<T>>(loadJson);
    }
}
