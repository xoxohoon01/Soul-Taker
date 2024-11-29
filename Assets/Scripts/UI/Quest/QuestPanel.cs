using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DataTable;

public class QuestPanel : MonoBehaviour
{
    public QuestData Quest;
    public TMP_Text Name;
    public TMP_Text Description;

    public void Initiate()
    {
        Name.text = Quest.Name;
        Description.text = Quest.Description;
    }

    public void Select()
    {
        QuestManager.Instance.currentQuestKey = Quest.ID;
    }
}
