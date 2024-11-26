using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int MaxItems = 30;
    public List<ItemData> items = new List<ItemData>();
    public UIInventory inventoryUI;

    public bool AddItem(ItemData itemData)
    {
        if (items.Count >= MaxItems)
        {
            return false;
        }

        items.Add(itemData);
        return true;
    }

    public void RemoveItem(ItemData itemData)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (inventoryUI.slots[i].index == itemData.itemId)
            {
                items.Remove(items[i]);
            }
        }
        
    }
    
    public void RemoveItem(int number)
    {
        items[number] = new ItemData();
    }
}