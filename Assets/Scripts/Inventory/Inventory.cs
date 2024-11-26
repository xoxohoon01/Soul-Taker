using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
    public Transform slotPanel;
    public UIInventory uiInventory;

    private void Start()
    {
        uiInventory.gameObject.SetActive(false);
        uiInventory.slots = new ItemSlot[slotPanel.childCount];

        for (int i = 0; i < uiInventory.slots.Length; i++)
        {
            uiInventory.slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            uiInventory.slots[i].index = i;
            uiInventory.slots[i].inventory = uiInventory;
        }
    }

    public void Toggle()
    {
        if (IsOpen())
        {
            uiInventory.gameObject.SetActive(false);
        }
        else
        {
            uiInventory.gameObject.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return uiInventory.gameObject.activeInHierarchy;
    }
    
    public void AddItem(ItemData data)
    {
        //ItemData data = CharacterManager.Instance.Player.itemData;

        if (data.canStack)
        {
            ItemSlot slot = GetItemStack(data);
            if(slot != null)
            {
                slot.quantity++;
                uiInventory.UpdateUI();
                //CharacterManager.Instance.Player.itemData = null;
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            uiInventory.UpdateUI();
            //CharacterManager.Instance.Player.itemData = null;
            return;
        }

        RemoveItem(data.itemId);
        //CharacterManager.Instance.Player.itemData = null;
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < uiInventory.slots.Length)
        {
            uiInventory.slots[index].item = null;
            uiInventory.UpdateUI();
        }
    }
    
    ItemSlot GetItemStack(ItemData data)
    {
        for(int i = 0; i < uiInventory.slots.Length; i++)
        {
            if (uiInventory.slots[i].item == data && uiInventory.slots[i].quantity < data.maxStackAmount)
            {
                return uiInventory.slots[i];
            }
        }
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for(int i = 0; i < uiInventory.slots.Length; i++)
        {
            if (uiInventory.slots[i].item == null)
            {
                return uiInventory.slots[i];
            }
        }
        return null;
    }
}