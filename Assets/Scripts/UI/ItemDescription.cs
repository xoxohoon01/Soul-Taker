using System;
using System.Collections;
using System.Collections.Generic;
using DataTable;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : UIBase            //UIManager 통해 생성하기
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private TextMeshProUGUI textItemDescriptionTitle;
    [SerializeField] private Image itemImage;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button destructionButton;
    
    private ItemInstance _item;

    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        ButtonInitialize();
        Refresh();
    }

    private void Refresh()
    {
        ItemData data = DataManager.Instance.Item.GetItemData(_item.itemId);
        textName.text = data.displayName;
        textDescription.text = data.description;

        SetButton();
    }
    
    private void ButtonInitialize()
    {
        closeButton.onClick.AddListener(() => Hide());
        useButton.onClick.AddListener(() => ItemInitializeCount());
        equipButton.onClick.AddListener(() =>
        {
            ItemManager.Instance.RefreshListEquip(_item.id);
            DeleteItem();
        });
        unEquipButton.onClick.AddListener(() =>
        {
            ItemManager.Instance.RefreshListEquip(_item.id);
            DeleteItem();
        });
        destructionButton.onClick.AddListener(() => ItemInitializeCount());
    }

    private void SetButton()
    {
        useButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
        unEquipButton.gameObject.SetActive(false);
        
        var data = DataManager.Instance.Item.GetItemData(_item.itemId);

        if (data.itemType == ItemType.Consumption)
        {
            useButton.gameObject.SetActive(true);
            return;
        }

        if (data.itemType == ItemType.Misc)
        {
            return;
        }
        
        if (ItemManager.Instance.FindItemEquip(data.itemType))
        {
            unEquipButton.gameObject.SetActive(true);
            Debug.Log("unEquipButton 활성화");
        }
        else 
        {
            equipButton.gameObject.SetActive(true);
            Debug.Log("equipButton 활성화");
        }
    }

    private void DeleteItem()
    {
        Hide();
        HUD.Instance.OnInventory();
    }

    private void ItemInitializeCount()
    {
        if (_item.count >= 2)
        {
            _item.count--;
            Hide();
            HUD.Instance.OnInventory();
        }
        else
        {
            ItemManager.Instance.DeleteItem(_item.id);
            DeleteItem();
        }
    }
}
