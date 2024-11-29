using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataTable;

public class QuestListPanel : MonoBehaviour
{
    public ScrollRect scroll;
    public GameObject questPanel;

    public void AddQuest(QuestData newQuest)
    {
        QuestPanel newQuestPanel = Instantiate(questPanel, scroll.content).GetComponent<QuestPanel>();
        newQuestPanel.Quest = newQuest;
        newQuestPanel.Initiate();
    }
}
