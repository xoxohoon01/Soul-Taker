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

    private List<ItemInstance> _items;

    public void Initialize(List<ItemInstance> items)
    {
        _items = items;
        OnEquipment();
    }

    public void OnEquipment()
    {
        Refresh(ItemType.Equipment);
    }
    
    public void OnConsumption()
    {
        Refresh(ItemType.Consumption);
    }
    
    public void OnMisc()
    {
        Refresh(ItemType.Misc);
    }
    
    public void Refresh(ItemType type)
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

    public void OnClose()
    {
        Hide();
    }

    private void DeleteCell()
    {
        foreach (Transform child in trsParent)
        {
            Destroy(child.gameObject);
        }
    }
}
