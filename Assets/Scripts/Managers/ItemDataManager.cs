using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;
using UnityEditor;

public class ItemDataManager : ItemData
{
    public ItemData GetItemData(int itemId)
    {
        return ItemDataMap[itemId];
    }

    public List<ItemData> GetItemDataListByType()
    {
        //return ItemDataList.FindAll(x => x.itemType == Weapon);
        return null;
    }
    
    public bool Equipment(int itemid)
    {
        switch (ItemDataMap[itemid].itemType)
        {
            case ItemType.Head:
            case ItemType.Body:
            case ItemType.Belt:
            case ItemType.Foot:
            case ItemType.Weapon:
            case ItemType.Ring:
                return true;
            default:
                return false;
        }
    }
}
