using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : UIBase
{
    private UIInventory inventory;
    
    public void OnInventory()
    {
        inventory = UIManager.Instance.Show<UIInventory>();
        inventory.Initialize(ItemManager.Instance.GetItems());
    }
}
