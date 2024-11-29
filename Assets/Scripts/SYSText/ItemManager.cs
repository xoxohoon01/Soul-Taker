using System.Collections;
using System.Collections.Generic;
using Database;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    private List<ItemInstance> _items;

    public void Initialize(List<ItemInstance> items)
    {
       _items = items;
    }

    public ItemInstance AddItem(int id)
    {
        return _items.Find(x => x.itemId == id);
    }
}
