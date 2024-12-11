using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataTable;
using UnityEngine;

public class ItemManager : MonoSingleton<ItemManager>
{
    [SerializeField]private List<ItemInstance> _items;

    public ItemInstance weaponInstance;
    public ItemInstance ringInstance;
    public ItemInstance headInstance;
    public ItemInstance bodyInstance;
    public ItemInstance beltInstance;
    public ItemInstance footInstance;
    
    private int nextId;

    public void Initialize(List<ItemInstance> items)
    {
       _items = items;
       AddId();
       EquipmentInitialize();
    }
    
    public void Initialize(ItemInstanceData items)          //인스펙터 창에서 추가한 아이템 리스트에 저장
    {
        _items = items.itemInstances;
        AddId();
        EquipmentInitialize();
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

    private void EquipmentInitialize()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].equip)
            {
                switch (DataManager.Instance.Item.GetItemData(_items[i].itemId).itemType)
                {
                    case ItemType.Weapon:
                        weaponInstance = _items[i];
                        break;
                    case ItemType.Ring:
                        ringInstance = _items[i];
                        break;
                    case ItemType.Head:
                        headInstance = _items[i];
                        break;
                    case ItemType.Body:
                        bodyInstance = _items[i];
                        break;
                    case ItemType.Belt:
                        beltInstance = _items[i];
                        break;
                    case ItemType.Foot:
                        footInstance = _items[i];
                        break;
                }
            }
        }
    }

    private void EquipmentRefresh(int itemid)
    {
        
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

    public void RefreshListEquip(int id)        //for문으로 아이템을 찾는게 맞나요????
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].id == id)
            {
                ItemInstance item = _items[i];
                item.equip = !item.equip;
                
                switch (DataManager.Instance.Item.GetItemData(_items[i].itemId).itemType)
                {
                    case ItemType.Weapon:
                        weaponInstance = item.equip ? item : null;
                        break;
                    case ItemType.Ring:
                        ringInstance = item.equip ? item : null;
                        break;
                    case ItemType.Head:
                        headInstance = item.equip ? item : null;
                        break;
                    case ItemType.Body:
                        bodyInstance = item.equip ? item : null;
                        break;
                    case ItemType.Belt:
                        beltInstance = item.equip ? item : null;
                        break;
                    case ItemType.Foot:
                        footInstance = item.equip ? item : null;
                        break;
                }
            }
        }
    }

    public void EquipItemChange(ItemType type)
    {
        switch (type)
        {
            case ItemType.Weapon:
                GetInstance(type).equip = false;
                weaponInstance = null;
                break;
            case ItemType.Ring:
                GetInstance(type).equip = false;
                ringInstance = null;
                break;
            case ItemType.Head:
                GetInstance(type).equip = false;
                headInstance = null;
                break;
            case ItemType.Body:
                GetInstance(type).equip = false;
                bodyInstance = null;
                break;
            case ItemType.Belt:
                GetInstance(type).equip = false;
                beltInstance = null;
                break;
            case ItemType.Foot:
                GetInstance(type).equip = false;
                footInstance = null;
                break;
        }
    }
    
    public bool EquipItem(ItemType type)
    {
        return GetInstance(type) != null;
    }

    private ItemInstance GetInstance(ItemType type)        //해당 부위 장착 여부 확인
    {
        return type switch
        {
            ItemType.Weapon => weaponInstance,
            ItemType.Ring => ringInstance,
            ItemType.Head => headInstance,
            ItemType.Body => bodyInstance,
            ItemType.Belt => beltInstance,
            ItemType.Foot => footInstance,
            _ => null
        };
    }
}
