using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAcceptButton : MonoBehaviour
{
    public string questKey;

    public void Accept()
    {
        QuestManager.Instance.AcceptQuest(questKey);
    }
}
