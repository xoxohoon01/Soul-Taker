using System;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class UIShowDungeon : UIBase
{
    //[SerializeField] private Text dungeonNameTxt;
    [SerializeField] private int targetDungeonID;
    public void InitalizeDungeonNameText(int _targetDungeonID)
    {
        Debug.Log(_targetDungeonID);
        //targetDungeonID = _targetDungeonID;
        //Debug.Log(DataManager.Instance.Dungeon.GetDungeonid(_targetDungeonID).Name);
        //dungeonNameTxt.text = DataManager.Instance.Dungeon.GetDungeonid(2001).Name;
    }
    public void DungeonSelect(int Index)
    {
        switch (Index)
        {
            case 0:
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("TestDungeon");
                break;

            case 1:
                SceneManager.sceneLoaded += OnSceneLoaded; 
                SceneManager.LoadScene("TestDungeon");
                break;
            case 2:
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("TestDungeon");
                break;
        }
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
