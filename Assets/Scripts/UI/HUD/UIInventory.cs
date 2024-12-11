using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    [SerializeField] private GameObject objCell;
    [SerializeField] private Transform trsParent;
    
    [SerializeField] private Button equipment;
    [SerializeField] private Button consumption;
    [SerializeField] private Button misc;
    [SerializeField] private Button closeButton;
    
    [SerializeField] private List<Transform> transforms;

    private List<ItemInstance> _items;

    private int page = 0;
    
    
    public void Initialize(List<ItemInstance> items)
    {
        _items = items;

        switch (page)
        {
            case 0:
                EquipmentRefresh();
                break;
            case 1:
                MiscRefresh(ItemType.Consumption);
                break;
            case 2:
                MiscRefresh(ItemType.Misc);
                break;
        }
        ButtonInitialize();
    }
    
    private void MiscRefresh(ItemType type)
    {
        DeleteCell();
        
        for (int i = 0; i < _items.Count; i++)
        {
            if (DataManager.Instance.Item.GetItemData(_items[i].itemId).itemType == type)
            {
                GameObject obj = Instantiate(objCell, trsParent);
                obj.GetComponent<ItemCell>().Initialize(_items[i]);   
            }
        }
    }

    private void EquipmentRefresh()
    {
        DeleteCell();

        GameObject obj;

        for (int i = 0; i < _items.Count; i++)
        {
            if (DataManager.Instance.Item.Equipment(_items[i].itemId))
            {
                if (_items[i].equip)                                        //장비가 장착했으면 장착한 곳에서 생성
                {
                    obj = Instantiate(objCell, transforms[(int)DataManager.Instance.Item.GetItemData(_items[i].itemId).itemType]);
                    obj.GetComponent<ItemCell>().Initialize(_items[i]);
                }
                else
                {
                    obj = Instantiate(objCell, trsParent);
                    obj.GetComponent<ItemCell>().Initialize(_items[i]);
                }
            }
        }
    }

    private void ButtonInitialize()
    {
        equipment.onClick.AddListener(() =>
        {
            page = 0;
            EquipmentRefresh();
        });
        consumption.onClick.AddListener(() =>
        {
            page = 1;
            MiscRefresh(ItemType.Consumption);
        });
        misc.onClick.AddListener(() =>
        {
            page = 2;
            MiscRefresh(ItemType.Misc);
        });
        closeButton.onClick.AddListener(() => Hide());
    }

    private void DeleteCell()
    {
        foreach (Transform child in trsParent)
        {
            Destroy(child.gameObject);
        }
        
        //Transforms 자식 오브젝트 삭제
        foreach (Transform part in transforms)
        {
            foreach (Transform child in part)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
