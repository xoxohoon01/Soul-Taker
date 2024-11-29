using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.Show<UIShowDungeon>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("나감");

        if (other.CompareTag("Player"))
        {
            UIManager.Instance.Hide<UIShowDungeon>();
        }
    }

}
