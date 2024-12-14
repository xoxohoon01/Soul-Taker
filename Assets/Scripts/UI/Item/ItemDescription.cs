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
    [SerializeField] private TextMeshProUGUI textEnhance;
    [SerializeField] private TextMeshProUGUI itemPurpose;
    [SerializeField] private Image itemImage;
    [SerializeField] private Image itemGrade;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button changeButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button destructionButton;
    
    private ItemInstance _item;

    private int _type;
    private string itemGradeKorean;

    public void Initialize(ItemInstance item, int type)
    {
        _item = item;
        _type = type;

        ButtonInitialize();
        Refresh();
    }

    private void Refresh()
    {
        ItemData data = DataManager.Instance.Item.GetItemData(_item.itemId);
        ItemGradeColor();
        textName.text = data.displayName;
        itemImage.sprite = SpriteManager.Instance.SpriteReturn(data.icon);
        textEnhance.text = _item.enhance > 0 ? $"+{_item.enhance}" : "";
        itemPurpose.text = $"{itemGradeKorean}{data.itemPurpose}";

        if (data.itemType == ItemType.Consumption || data.itemType == ItemType.Misc)
        {
            textItemDescriptionTitle.text = "아이템 설명 ";
            textDescription.text = data.description;
        }
       
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
        changeButton.onClick.AddListener(() =>
        {
            ItemManager.Instance.EquipItemChange(DataManager.Instance.Item.GetItemData(_item.itemId).itemType);
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
        changeButton.gameObject.SetActive(false);
        unEquipButton.gameObject.SetActive(false);
        destructionButton.gameObject.SetActive(false);

        if (_type == 0)
        {
            var data = DataManager.Instance.Item.GetItemData(_item.itemId);

            if (data.itemType == ItemType.Consumption)
            {
                useButton.gameObject.SetActive(true);
                destructionButton.gameObject.SetActive(true);
                return;
            }

            if (data.itemType == ItemType.Misc)
            {
                return;
            }


            if (ItemManager.Instance.EquipItem(DataManager.Instance.Item.GetItemData(_item.itemId).itemType))
            {
                if (_item.equip)
                {
                    unEquipButton.gameObject.SetActive(true);
                    destructionButton.gameObject.SetActive(true);
                }
                changeButton.gameObject.SetActive(true);
                destructionButton.gameObject.SetActive(true);
            }
            else
            {
                equipButton.gameObject.SetActive(true);
                destructionButton.gameObject.SetActive(true);
            }
        }
        
        
        /*
        if (ItemManager.Instance.FindItemEquip(data.itemType))
        {
            unEquipButton.gameObject.SetActive(true);
        }
        else 
        {
            equipButton.gameObject.SetActive(true);
        }
        */
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

    private void ItemGradeColor()
    {
        switch (_item.gradeType)
        {
            case ItemGradeType.Normal:
                itemGrade.color = Color.gray;
                textName.color = Color.gray;
                itemGradeKorean = "일반";
                break;
            case ItemGradeType.Uncommon:
                itemGrade.color = Color.green;
                textName.color = Color.green;
                itemGradeKorean = "고급";
                break;
            case ItemGradeType.Rare:
                itemGrade.color = Color.blue;
                textName.color = Color.blue;
                itemGradeKorean = "희귀";
                break;
            case ItemGradeType.Legend:
                itemGrade.color = Color.yellow;
                textName.color = Color.yellow;
                itemGradeKorean = "전설";
                break;
        }
    }
}
