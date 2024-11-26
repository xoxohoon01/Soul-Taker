using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] itemSlots;
    public GameObject inventoryUI;
    public Transform slotPanel;

    private void Start()
    {
        inventoryUI.SetActive(false);
        itemSlots = new ItemSlot[slotPanel.childCount];

        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            itemSlots[i].index = i;
            itemSlots[i].inventory = this;
        }
    }

    public void Toggle()
    {
        if (IsOpen())
        {
            inventoryUI.SetActive(false);
        }
        else
        {
            inventoryUI.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return inventoryUI.activeInHierarchy;
    }

    public void AddItem(ItemData itemData)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                itemSlots[i].item = itemData;
                UpdateUI();
                return;
            }
        }
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < itemSlots.Length)
        {
            itemSlots[index].item = null;
            UpdateUI();
        }
    }
    
    private void UpdateUI()
    {
        
    }
}
