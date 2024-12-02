using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DataTable;

public class QuestManager : MonoSingleton<QuestManager>
{
    public GameObject questCanvas;

    [SerializeField] private SerializableDictionary<int, QuestData> _processingQuests;
    public SerializableDictionary<int, QuestData> processingQuests
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

    [SerializeField] private SerializableDictionary<int, QuestData> _completedQuests;
    public SerializableDictionary<int, QuestData> completedQuests
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

    public int currentQuestKey;

    public QuestData AcceptQuest()
    {
        if (!processingQuests.ContainsKey(currentQuestKey) && !completedQuests.ContainsKey(currentQuestKey))
        {
            processingQuests.Add(currentQuestKey, DataManager.Instance.Quest.GetQuestDatas()[currentQuestKey]);

            return processingQuests[currentQuestKey];
        }
        else
        {
            return null;
        }
    }
    
    public QuestData DeclineQuest()
    {
        if (processingQuests.ContainsKey(currentQuestKey))
        {
            processingQuests.Remove(currentQuestKey, out QuestData removedQuest);
            return removedQuest;
        }
        else
        {
            return null;
        }
    }

    public void CompleteQuest()
    {
        processingQuests.Remove(currentQuestKey, out QuestData completedQuest);
        completedQuests.Add(currentQuestKey, completedQuest);
    }

    private new void Awake()
    {
        base.Awake();
        questList = Instantiate(questCanvas).transform.GetChild(0).GetComponent<QuestListPanel>();
    }

    private void Start()
    {
        foreach (QuestData quest in DataManager.Instance.Quest.GetQuestDatas())
        {
            questList.AddQuest(quest);
        }
    }
}
