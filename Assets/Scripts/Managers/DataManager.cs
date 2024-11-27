using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UGS;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    void Awake()
    {
        // 구글시트 불러오기
        UnityGoogleSheet.LoadAllData();
    }

}
