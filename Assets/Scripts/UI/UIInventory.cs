using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;
    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Inventory inventory;
    
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    
    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;
    
    public void Toggle()            //인벤토리 키 눌렀을때 인벤토리 나오게 하는 함수
    {
        if (IsOpen())
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }
    
    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
    
    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDescription.text = selectedItem.item.description;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        for(int i = 0; i< selectedItem.item.consumables.Length; i++)
        {
            selectedItemStatName.text += selectedItem.item.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.item.consumables[i].value.ToString() + "\n";
        }

        useButton.SetActive(selectedItem.item.Type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.Type == ItemType.Equipable && !slots[index].equipped);
        unEquipButton.SetActive(selectedItem.item.Type == ItemType.Equipable && slots[index].equipped);
        dropButton.SetActive(true);
    }

    void ClearSelectedItemWindow()
    {
        selectedItem = null;

        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void OnUseButton()
    {
        if(selectedItem.item.Type == ItemType.Consumable)
        {
            for(int i = 0; i < selectedItem.item.consumables.Length; i++)
            {
                switch (selectedItem.item.consumables[i].type)
                {
                    case ConsumableType.Health:
                        //condition.Heal(selectedItem.item.consumables[i].value); break;
                    case ConsumableType.Hunger:
                        //condition.Eat(selectedItem.item.consumables[i].value);break;
                        break;
                }
            }
            RemoveSelctedItem();
        }
    }

    public void OnDropButton()
    {
        inventory.RemoveItem(selectedItem.item.itemId);
        RemoveSelctedItem();
    }

    void RemoveSelctedItem()
    {
        selectedItem.quantity--;

        if(selectedItem.quantity <= 0)
        {
            selectedItem = null;
            slots[selectedItemIndex].item = null;       //인벤토리 UI아이템 사라지게하는 코드
            selectedItemIndex = -1;
            ClearSelectedItemWindow();
        }

        UpdateUI();
    }

    public bool HasItem(ItemData item, int quantity)
    {
        return false;
    }
}
