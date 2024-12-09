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
        ItemManager.Instance.Initialize(DatabaseManager.Instance.LoadDataList<ItemInstance>());
    }

    public void Start()
    {
        HUD.Instance.Initialize();
        /* UIManager.Instance.Initialize();*/ // 캔버스 동적 생성할 거라면
    }

}
