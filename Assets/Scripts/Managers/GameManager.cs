using System.Collections;
using System.Collections.Generic;
using System.IO;
using Database;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public ItemInstance items;

    private new void Awake()
    {
        base.Awake();
        DatabaseManager.Instance.Initialize();
    }
}
