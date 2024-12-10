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
    
    public bool FindItemEquip(ItemType type)     //아이템 타입을 찾아서 해당 아이템이 장착 중이면 true/ 아이템이 없으면 false      (장착 버튼을 기준으로 생각)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (DataManager.Instance.Item.GetItemData(_items[i].itemId).itemType == type)
            {
                if (_items[i].equip)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void RefreshListEquip(int id)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].id == id)
            {
                var item = _items[i];
                item.equip = !item.equip;
                Debug.Log($"아이템 장착 불값 변경{item.equip}");
            }
        }
    }
}
