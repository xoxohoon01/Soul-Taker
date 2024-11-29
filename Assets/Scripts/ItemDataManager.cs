using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class ItemDataManager : ItemData
{
    public List<ItemData> GetItemDatas()
    {
        return ItemDataList;
    }

    public ItemData GetItemData(int id)
    {
        return ItemDataMap[id];
    }
}
