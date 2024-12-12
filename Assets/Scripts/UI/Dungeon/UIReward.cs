using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class UIReward : UIBase
{
    [SerializeField] private GameObject _itemListPanel;
    [SerializeField] private GameObject _itemCell;

    public void ShowDisplay(int currentRewardID) // 아이템 ID 리스트 전달 
    {
        var rewardData = DataManager.Instance.Object.GetObjectid(currentRewardID);

        

        List<int> itemList = rewardData.item; // 아이템 ID 리스트로 저장
        List<int> itemCountList = rewardData.itemCount; // ID랑 매칭되는 COUNT 리스트로 저장
        ItemInstance itemInstances = new ItemInstance(); // 아이템 인스턴스를 저장할 

        for (int i = 0; i < itemList.Count; i++) // 아이템 리스트의 수만큼 반복하며 itemID를 추출 
        {
            int itemID = itemList[i]; 
            int itemCount = itemCountList[i];
                     
            GameObject goItem = Instantiate(_itemCell, _itemListPanel.transform);
            goItem.GetComponent<ItemCell>().Initialize(ItemManager.Instance.AddItem(itemID, itemCount), 1); 
        }
    }
}

