using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIClearDuneon : UIBase
{
    public void OnClick()
    {
        SceneManager.LoadScene("Town");
    }
}
