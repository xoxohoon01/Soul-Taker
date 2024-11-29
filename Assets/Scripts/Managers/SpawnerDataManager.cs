using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class SpawnerDataManager : SpawnerData
{
    public Dictionary<string, SpawnerData> GetSpawnerDatas()
    {
        return SpawnerDataMap;
    }
}
