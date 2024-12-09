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
        
        Refresh();
        ButtonInitialize();
    }

    private void Refresh()
    {
        ItemData data = DataManager.Instance.Item.GetItemData(_item.itemId);
        textName.text = data.displayName;
        textDescription.text = data.description;

        if (DataManager.Instance.Item.GetItemData(_item.itemId).itemType == ItemType.Equipment)
        {
            useButton.gameObject.SetActive(false);
            if (_item.equip == false)
            {
                unEquipButton.gameObject.SetActive(false);
            }
        }
        else if(DataManager.Instance.Item.GetItemData(_item.itemId).itemType == ItemType.Consumption)
        {
            equipButton.gameObject.SetActive(false);
            unEquipButton.gameObject.SetActive(false);
        }
        
    }
    
    private void ButtonInitialize()
    {
        closeButton.onClick.AddListener(() => Hide());
        //useButton.onClick.AddListener(() => );
        equipButton.onClick.AddListener(() =>
        {
            _item.equip = true;
            UIManager.Instance.Show<EquipmentSlot>().Initialize(_item);
            DeleteItem();
        });
        //unEquipButton.onClick.AddListener(() => );
        destructionButton.onClick.AddListener(() =>
        {
            if (_item.count >= 2)
            {
                _item.count--;
                Hide();
                HUD.Instance.OnInventory();
            }
            else
            {
                DeleteItem();
            }
        });
    }

    private void DeleteItem()
    {
        ItemManager.Instance.DeleteItem(_item.id);
        Hide();
        HUD.Instance.OnInventory();
    }
}
