using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
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
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }
        
        string loadJson = File.ReadAllText(Application.persistentDataPath + $"/{typeof(T)}.txt");
        return JsonConvert.DeserializeObject<List<T>>(loadJson);
    }
}
