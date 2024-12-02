using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int targetDungeonID;
    [SerializeField] private UIShowDungeon UIShowDungeon;

    private void Start()
    {
        UIShowDungeon = GetComponent<UIShowDungeon>();
    }

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
