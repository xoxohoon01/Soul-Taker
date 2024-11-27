using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using TMPro;
using UGS;

public class DatabaseManager : MonoSingleton<DatabaseManager>
{
    private new void Awake()
    {
        // 구글시트 불러오기
        UnityGoogleSheet.LoadAllData();
    }

    private void Start()
    {

    }
}