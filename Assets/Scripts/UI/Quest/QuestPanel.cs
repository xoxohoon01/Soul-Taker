using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPanel : MonoBehaviour
{
    public Database.Quests Quest;
    public TMP_Text Name;
    public TMP_Text Description;

    public void Initiate()
    {
        Name.text = Quest.Name;
        Description.text = Quest.Description;
    }
}
