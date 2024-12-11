using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RewardBox : MonoBehaviour
{
    private int _currentRewardID; // 0 나옴 

    public void Initalize(int currentRewardID)
    {
        _currentRewardID = currentRewardID;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIReward uiReward = UIManager.Instance.Show<UIReward>() as UIReward;

            if (uiReward != null)
            {
                uiReward.ShowDisplay(_currentRewardID);
            }
        }
    }
}

