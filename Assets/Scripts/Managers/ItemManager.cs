using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataTable;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    private List<ItemInstance> _items;
    private int nextId;

    public void Initialize(List<ItemInstance> items)
    {
       _items = items;
       AddId();
    }

    public void AddItem(int id)     //아이템 추가하는 로직
    {
        var item = new ItemInstance();
        {
            item.id = nextId;
            item.itemId = id;
            item.enhance = 0;
        }
        
        _items.Add(item);
        DatabaseManager.Instance.SaveData(_items);
    }

    private void AddId()            //아이템 번호 부여하는 로직
    {
        if (_items != null && _items.Count > 0)
        {
            nextId = _items.Max(x => x.id) + 1;
        }
        else
        {
            nextId = 0;
        }
    }
}
