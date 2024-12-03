using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIShowDungeon : UIBase
{
    [SerializeField] private Text dungeonNameTxt;
    [SerializeField] private int targetDungeonID;
    [SerializeField] private string targetDungeonSceneName;
    public void InitalizeDungeonNameText(int _targetDungeonID)
    {
        targetDungeonID = _targetDungeonID;
        targetDungeonSceneName = DataManager.Instance.Dungeon.GetDungeonid(_targetDungeonID).Scene;
        dungeonNameTxt.text = DataManager.Instance.Dungeon.GetDungeonid(_targetDungeonID).Name;
        Debug.Log(targetDungeonSceneName);
    }
    public void DungeonSelect()
    {
        //switch (Index)
        //{
        //    case 0:
        //        SceneManager.sceneLoaded += OnSceneLoaded;
        //        SceneManager.LoadScene(targetDungeonSceneName);
        //        break;

        //    case 1:
        //        SceneManager.sceneLoaded += OnSceneLoaded;
        //        SceneManager.LoadScene(targetDungeonSceneName);
        //        break;
        //    case 2:
        //        SceneManager.sceneLoaded += OnSceneLoaded;
        //        SceneManager.LoadScene(targetDungeonSceneName);
        //        break;
        //}

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(targetDungeonSceneName);
        UIManager.Instance.Hide<UIShowDungeon>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestDungeon")
        {
            DungeonManager.Instance.InitializeDungeon(targetDungeonID); // InitializeDungeon 호출
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트 해제
    }
}
