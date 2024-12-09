using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HUD : MonoSingleton<HUD>
{
    private Canvas _hudCanvasPrefab;
    public Canvas _hudCanvas;

    private GameObject _hudPrefab;
    public GameObject _hud;
    
    private GameObject _joyStickPrefab;
    public GameObject _joyStick;

    private UIInventory inventory;

    public void Initialize()
    {
        if (_hudCanvas == null)
        {
            _hudCanvasPrefab = Resources.Load<Canvas>("UI/HUDCanvas");
            _hudCanvas = Object.Instantiate(_hudCanvasPrefab);
            DontDestroyOnLoad(_hudCanvas);
        }

        if (_hudPrefab == null)
        {
            _hudPrefab = Resources.Load<GameObject>("UI/HUD");
            _hud = Object.Instantiate(_hudPrefab, _hudCanvas.transform);
        }

        if (_joyStickPrefab == null)
        {
            _joyStickPrefab = Resources.Load<GameObject>("UI/Joystick");
            _joyStick = Object.Instantiate(_joyStickPrefab, _hudCanvas.transform);
        }
    }

    public void OnInventory()
    {
        inventory = UIManager.Instance.Show<UIInventory>();
        inventory.Initialize(ItemManager.Instance.GetItems());
    }
}
