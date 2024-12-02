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
        DatabaseManager.Instance.Initialize();
        
        ItemManager.Instance.Initialize(DatabaseManager.Instance.Parse(typeof(ItemInstance).ToString()));
    }
}
