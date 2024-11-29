using UnityEngine.SceneManagement;
public class UIShowDungeon : UIBase
{
    private int targetDungeonID;
    public void DungeonSelect(int Index)
    {
        switch (Index)
        {
            case 0:
                targetDungeonID = 2001; 
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("YJ");
                break;

            case 1:
                targetDungeonID = 2002; 
                SceneManager.sceneLoaded += OnSceneLoaded; 
                SceneManager.LoadScene("YJ");
                break;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "YJ")
        {
            DungeonManager.Instance.InitializeDungeon(targetDungeonID); // InitializeDungeon 호출
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트 해제
    }
}
