using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public void OnInventory()
    {
        UIInventory inventory = UIManager.Instance.Show<UIInventory>();
        inventory.Initialize(ItemManager.Instance.GetItems());
    }

    public void OnClose()
    {
        
    }
}
