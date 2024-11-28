using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Database;
using static UnityEditor.Progress;
using UGS;

public class QuestDataManager : Quests
{
    public List<Quests> GetQuestDatas()
    {
        DatabaseManager.Instance.Initialize();
        return QuestsList;
    }
}
