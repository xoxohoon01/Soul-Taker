using DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDataManager : DungeonData
{
    public List<DungeonData> GetDungeon()
    {
        return DungeonDataList;
    }

    public DungeonData GetDungeonid(int DungeonId)
    {
        return DungeonDataList.Find(x => x.ID == DungeonId);
    }
}
