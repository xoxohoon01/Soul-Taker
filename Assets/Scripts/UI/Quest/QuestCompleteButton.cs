using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleteButton : MonoBehaviour
{
    public string questKey;

    public void Complete()
    {
        QuestManager.Instance.CompleteQuest(questKey);
    }
}
