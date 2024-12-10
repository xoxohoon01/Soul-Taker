using System.Collections;
using System.Collections.Generic;
using System.IO;
using DataTable;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject _joyStick;

    private new void Awake()
    {
        base.Awake();
        DataManager.Instance.Initialize();
        ItemManager.Instance.Initialize(DatabaseManager.Instance.LoadDataList<ItemInstance>());
    }

    public void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        GameObject hudPrefab = Resources.Load<GameObject>("UI/HUD");
        if (hudPrefab != null)
            Instantiate(hudPrefab);

        GameObject joyStickPrefab = Resources.Load<GameObject>("UI/Joystick");
        if (joyStickPrefab != null)
            _joyStick = Instantiate(joyStickPrefab, HUD.Instance.transform);
    }
}
