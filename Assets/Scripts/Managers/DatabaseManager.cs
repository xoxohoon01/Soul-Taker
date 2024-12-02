using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    public string savePath = Application.persistentDataPath;

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
}
