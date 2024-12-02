using System.Collections;
using System.Collections.Generic;
using System.IO;
using DataTable;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private new void Awake()
    {
        base.Awake();
        DataManager.Instance.Initialize();
        
        //ItemManager.Instance.Initialize(DataManager.Instance.LoadData(typeof(ItemInstance).ToString()));
    }
}
