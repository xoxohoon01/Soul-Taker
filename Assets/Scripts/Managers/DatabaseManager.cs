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
        // ���۽�Ʈ �ҷ�����
        UnityGoogleSheet.LoadAllData();
    }

    private void Start()
    {

    }
}