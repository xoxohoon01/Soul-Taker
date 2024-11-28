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
    private new void Awake()
    {
        // 구글시트 불러오기
        UnityGoogleSheet.LoadAllData();
    }

    public T Parse<T>(object target)
    {
        string data = JsonUtility.ToJson(target);

        return JsonUtility.FromJson<T>(data);
    }
}