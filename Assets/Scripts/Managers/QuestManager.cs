using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Database;

public class QuestManager : MonoSingleton<QuestManager>
{
    public GameObject questCanvas;

    [SerializeField] private SerializableDictionary<string, Quest> _processingQuests;
    public SerializableDictionary<string, Quest> processingQuests
    {
        get
        {
            return _processingQuests;
        }
        set
        {
            // UI Manager에 Quest 변동사항 전송
            _processingQuests = value;
        }
    }

    [SerializeField] private SerializableDictionary<string, Quest> _completedQuests;
    public SerializableDictionary<string, Quest> completedQuests
    {
        get
        {
            return _completedQuests;
        }
        set
        {
            // UI Manager에 Quest 변동사항 전송
            _completedQuests = value;
        }
    }

    private QuestListPanel questList;

    public Quest AcceptQuest(string questKey)
    {
        if (!processingQuests.ContainsKey(questKey) && !completedQuests.ContainsKey(questKey))
        {
            processingQuests.Add(questKey, DatabaseManager.Instance.Parse<Quest>(Quest.QuestMap[questKey]));

            return processingQuests[questKey];
        }
        else
        {
            return null;
        }
    }
    
    public Quest DeclineQuest(string questKey)
    {
        if (processingQuests.ContainsKey(questKey))
        {
            processingQuests.Remove(questKey, out Quest removedQuest);
            return removedQuest;
        }
        else
        {
            return null;
        }
    }

    public void CompleteQuest(string questKey)
    {
        processingQuests.Remove(questKey, out Quest completedQuest);
        completedQuests.Add(questKey, completedQuest);
    }

    private new void Awake()
    {
        base.Awake();
        questList = Instantiate(questCanvas).transform.GetChild(0).GetComponent<QuestListPanel>();
    }

    private void Start()
    {
        foreach (Quest quest in DatabaseManager.Instance.Quest.GetQuestDatas())
        {
            questList.AddQuest(quest);
        }
    }
}
