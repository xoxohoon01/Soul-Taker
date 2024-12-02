using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class ItemDataManager : ItemData
{
    public ItemData GetItemData(int id)
    {
        return ItemDataMap[id];
    }

    public List<ItemData> GetItemDataListByType()
    {
        //return ItemDataList.FindAll(x => x.itemType == Weapon);
        return null;
    }
}
