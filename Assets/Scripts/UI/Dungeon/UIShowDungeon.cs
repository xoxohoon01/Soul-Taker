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
        targetDungeonSceneName = DataManager.Instance.Dungeon.GetDungeonid(_targetDungeonID).scene;
        dungeonNameTxt.text = DataManager.Instance.Dungeon.GetDungeonid(_targetDungeonID).name;
        Debug.Log(targetDungeonSceneName);
    }
    public void DungeonSelect()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(targetDungeonSceneName);
        UIManager.Instance.Hide<UIShowDungeon>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetDungeonSceneName)
        {
            DungeonManager.Instance.EnterDungeon(targetDungeonID); // InitializeDungeon 호출
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트 해제
    }
}