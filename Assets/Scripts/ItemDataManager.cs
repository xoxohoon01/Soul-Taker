using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Database;

public class ItemDataManager : Items
{
    public List<Items> GetItemDatas()
    {
        return ItemsList;
    }

    public Items GetItemid(int index)
    {
        return ItemsMap[index];
    }
}
