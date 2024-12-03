using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Tooltip("해당 포탈에 맞는 던전ID를 입력해주세요.")]
    [SerializeField] private int targetDungeonID;
    [Tooltip("던전 UI를 연결해주세요.")]
    [SerializeField] private UIShowDungeon UIShowDungeon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIShowDungeon.InitalizeDungeonNameText(targetDungeonID);
            UIManager.Instance.Show<UIShowDungeon>();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.Hide<UIShowDungeon>();
        }
    }

}
