using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using TMPro;
using UGS;
using Database;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    public ItemDataManager Item;
    public QuestDataManager Quest;
    public void Initialize()
    {
        UnityGoogleSheet.LoadAllData();
        Item = new ItemDataManager();
        Quest = new QuestDataManager();
    }

    public T Parse<T>(object target)
    {
        string data = JsonUtility.ToJson(target);

        return JsonUtility.FromJson<T>(data);
    }
}