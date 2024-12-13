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
        if (!ItemDataMap.ContainsKey(itemid)) {
            Debug.LogError("Item ID not found in the dictionary: " + itemid);
            return false; // 또는 처리할 로직
        }
        
        switch (ItemDataMap[itemid].itemType)
        {
            case ItemType.Weapon:
            case ItemType.Ring:
            case ItemType.Head:
            case ItemType.Body:
            case ItemType.Belt:
            case ItemType.Foot:
                return true;
            default:
                return false;
        }
    }
}
