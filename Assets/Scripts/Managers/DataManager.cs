using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UGS;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    void Awake()
    {
        // ���۽�Ʈ �ҷ�����
        UnityGoogleSheet.LoadAllData();
    }

}
