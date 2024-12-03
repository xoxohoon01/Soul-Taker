using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIInventory : UIBase
{
    [SerializeField] private GameObject objCell;
    [SerializeField] private Transform trsParent;

    private List<ItemInstance> _items;

    public void Initialize(List<ItemInstance> items)
    {
        _items = items;
        Refresh();
    }
    
    private void Refresh()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            GameObject obj = Instantiate(objCell, trsParent);
            obj.GetComponent<ItemCell>().Initialize(_items[i]);
        }
    }
}
