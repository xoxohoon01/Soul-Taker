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

    private List<ItemInstance> _items;

    public void Initialize(List<ItemInstance> items)
    {
        _items = items;
        Refresh(ItemType.Equipment);

        ButtonInitialize();
    }
    
    private void Refresh(ItemType type)
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

    private void ButtonInitialize()
    {
        equipment.onClick.AddListener(() => Refresh(ItemType.Equipment));
        consumption.onClick.AddListener(() => Refresh(ItemType.Consumption));
        misc.onClick.AddListener(() => Refresh(ItemType.Misc));
        closeButton.onClick.AddListener(() => Hide());
    }

    private void DeleteCell()
    {
        foreach (Transform child in trsParent)
        {
            Destroy(child.gameObject);
        }
    }
}
