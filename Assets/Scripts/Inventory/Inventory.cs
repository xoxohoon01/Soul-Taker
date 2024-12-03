using System.Collections;
using System.Collections.Generic;
using DataTable;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
    [SerializeField] private GameObject objCell;

    private List<ItemInstance> _items;

    public void Initialize(List<ItemInstance> items)
    {
        _items = items;

        Refresh();
    }

    private void Refresh()
    {
        
    }
}