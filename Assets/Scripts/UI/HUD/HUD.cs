using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HUD : MonoSingleton<HUD>
{
    public void OnInventory()
    {
        UIManager.Instance.Show<UIInventory>().Initialize(ItemManager.Instance.GetItems());
    }
}
