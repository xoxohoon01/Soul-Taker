using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    private UIInventory inventory;
    
    public void OnInventory()
    {
        inventory = UIManager.Instance.Show<UIInventory>();
        inventory.Initialize(ItemManager.Instance.GetItems());
    }

    public void OnClose()
    {
        inventory.Hide();
        inventory = null;
    }
}
