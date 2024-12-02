using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class MonsterDataManager : MonsterData
{
    public MonsterData GetMonster(int id)
    {
        return MonsterDataMap[id];
    }
}
