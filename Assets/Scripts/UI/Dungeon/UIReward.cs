using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class UIReward : UIBase
{
    [SerializeField] private GameObject _itemListPanel;

    public void ShowDisplay(int currentRewardID) // 아이템 ID 리스트 전달 
    {
        var rewardData = DataManager.Instance.Object.GetObjectid(currentRewardID);

        List<int> itemList = rewardData.item; 
        List<int> itemCountList = rewardData.itemCount;


        for (int i = 0; i < itemList.Count; i++)
        {
            int itemID = itemList[i];
            int itemCount = itemCountList[i];

            // 그냥 아이템셀에 아이템 아이디만 넘겨주면 되는데.. 
            GameObject itemPrefab = Resources.Load<GameObject>("UI/HUD/Inventory/ItemCell");
            GameObject goItem = Instantiate(itemPrefab, _itemListPanel.transform);
            //goItem.GetComponent<ItemCell>().Initialize(itemID);
        }
    }
}

