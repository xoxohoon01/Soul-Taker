using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDeclinetButton : MonoBehaviour
{
    public string questKey;

    public void Decline()
    {
        QuestManager.Instance.DeclineQuest();
    }
}
