using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int targetDungeonID;
    [SerializeField] private UIShowDungeon UIShowDungeon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(DataManager.Instance.Dungeon.GetDungeon()[0].ID);
            Debug.Log("플레이어를 감지했다.");
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
