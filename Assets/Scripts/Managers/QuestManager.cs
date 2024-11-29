using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DataTable;

public class QuestManager : MonoSingleton<QuestManager>
{
    public GameObject questCanvas;

    [SerializeField] private SerializableDictionary<string, QuestData> _processingQuests;
    public SerializableDictionary<string, QuestData> processingQuests
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

    [SerializeField] private SerializableDictionary<string, QuestData> _completedQuests;
    public SerializableDictionary<string, QuestData> completedQuests
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

    public string currentQuestKey;

    public QuestData AcceptQuest()
    {
        if (!processingQuests.ContainsKey(currentQuestKey) && !completedQuests.ContainsKey(currentQuestKey))
        {
            processingQuests.Add(currentQuestKey, DatabaseManager.Instance.Quest.GetQuestDatas()[currentQuestKey]);

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
        //foreach (QuestData quest in DatabaseManager.Instance.Quest.GetQuestDatas())
        //{
        //    questList.AddQuest(quest);
        //}
    }
}
