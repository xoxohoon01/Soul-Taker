using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class QuestDataManager : QuestData
{
    public List<QuestData> GetQuestDatas()
    {
        return QuestDataList;
    }
}
