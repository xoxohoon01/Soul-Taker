using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class SpawnerDataManager : SpawnerData
{
    public List<SpawnerData> GetDungeon()
    {
        return SpawnerDataList;
    }
    public SpawnerData GetSpawnerid(int SpawnerId)
    {
        return SpawnerDataList.Find(x => x.ID == SpawnerId);
    }
}
