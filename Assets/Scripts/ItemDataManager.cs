using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Database;

public class ItemDataManager : Items
{
    public List<Items> GetItemDatas()
    {
        return Database.Items.ItemsList;
    }
}
