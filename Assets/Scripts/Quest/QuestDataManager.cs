using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Database;

public class QuestDataManager : Quest
{
    public List<Quest> GetQuestDatas()
    {
        return QuestList;
    }
}
