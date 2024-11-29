using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class QuestDataManager : QuestData
{
    public Dictionary<string, QuestData> GetQuestDatas()
    {
        return QuestDataMap;
    }
}
