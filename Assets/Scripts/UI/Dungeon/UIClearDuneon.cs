using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIClearDungeon : UIBase
{
    public void OnClick()
    {
        SceneManager.LoadScene("Town");
        UIManager.Instance.Hide<UIClearDungeon>();
    }
}
