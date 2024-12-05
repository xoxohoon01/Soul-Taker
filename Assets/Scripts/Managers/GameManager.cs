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
        
        UIManager.Instance.Show<HUD>();     //HUD 생성하는 코드 / 추후 위치가 바뀔 예정
    }
}
