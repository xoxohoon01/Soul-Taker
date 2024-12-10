using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reward : MonoBehaviour
{
    private List<int> _rewards;

    public void Initalize(int currentRewardID)
    {
        for (int i = 0;  i < DataManager.Instance.Dungeon.GetDungeonid(currentRewardID).reward.Count; i++)
        {
            _rewards.Add(i);
        }

        Debug.Log(_rewards);

    }

    private void OnClick() // 버튼 클릭으로 수정
    {
        UIManager.Instance.Show<UIReward>();

        // 여기서 _rewards의 정보를 전달 
    }
}

