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
    
    [SerializeField] private GameObject objDescription;
    private GameObject uiExplanation;
    
    [SerializeField] private Button equipment;
    [SerializeField] private Button consumption;
    [SerializeField] private Button misc;

    private List<ItemInstance> _items;

    public void Initialize(List<ItemInstance> items)
    {
        _items = items;
        Refresh();
        OnEquipment();
    }
    
    private void Refresh()
    {
        uiExplanation = Instantiate(objDescription, gameObject.transform);
        uiExplanation.SetActive(false);
    }

    public void OnEquipment()
    {
        ItemType(0);
    }
    
    public void OnConsumption()
    {
        ItemType(1);
    }
    
    public void OnMisc()
    {
        ItemType(2);
    }
    
    public void ItemType(int type)
    {
        Hide();
        
        for (int i = 0; i < _items.Count; i++)
        {
            if (DataManager.Instance.Item.GetItemData(_items[i].itemId).itemType == type)
            {
                GameObject obj = Instantiate(objCell, trsParent);
                obj.GetComponent<ItemCell>().Initialize(_items[i], uiExplanation);   
            }
        }
    }

    public void OnClose()
    {
        Hide();
    }
}
