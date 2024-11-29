using UnityEngine.SceneManagement;
public class UIShowDungeon : UIBase
{
    private void DungeonSelect(int Index)
    {
        switch (Index)
        {
            case 0:
                DungeonManager.Instance.InitializeDungeon(2001);
                SceneManager.LoadScene("YJ");
                break;
            case 1:
                DungeonManager.Instance.InitializeDungeon(2002);
                SceneManager.LoadScene("YJ");
                break;
        }
    }
}
