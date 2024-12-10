using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataTable;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    [SerializeField]private List<ItemInstance> _items;
    
    private int nextId;

    public void Initialize(List<ItemInstance> items)
    {
       _items = items;
       AddId();
    }
    
    public void Initialize(ItemInstanceData items)          //인스펙터 창에서 추가한 아이템 리스트에 저장
    {
        _items = items.itemInstances;
        AddId();
    }

    public void AddItem(int itemId)     //아이템 추가하는 로직
    {
        var item = new ItemInstance();
        {
            item.id = nextId;
            item.itemId = itemId;
            item.count = 1;
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

    public List<ItemInstance> GetItems()
    {
        return _items;
    }

    public void DeleteItem(int id)
    {
        _items.Remove(_items.Find(x => x.id == id));
    }

    public void AddList(ItemInstance item)
    {
        _items.Add(item);
    }
}
