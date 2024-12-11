using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIReward : UIBase
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private GameObject _itemListPanel;

    //public void ShowDisplay(List<int> itemlist) // 아이템 ID 리스트 전달 
    //{
    //    foreach (var itemID in itemlist)
    //    { 
    //        var itemData = DataManager.Instance.Item.GetItemData(itemID);
    //        GameObject itemPrefab = Resources.Load<GameObject>("RewardItem");
    //        GameObject itemInstance = Instantiate(itemPrefab, _itemListPanel.transform);
    //        _itemTxt.text = itemData.displayName; 
    //    }
    //}

    public void ShowDisplay(int currentRewardID) // 아이템 ID 리스트 전달 
    {
        //var rewardData = DataManager.Instance.Object.GetObjectid(currentRewardID);
        //List<int> itemList = rewardData.item;

        //foreach (var itemID in itemList)
        //{
        //    var itemData = DataManager.Instance.Item.GetItemData(itemID);
        //    GameObject itemPrefab = Resources.Load<GameObject>("RewardItem");
        //    GameObject itemInstance = Instantiate(itemPrefab, _itemListPanel.transform);
        //    _itemTxt.text = itemData.displayName;
        //    _itemCount.text = rewardData.itemCount;
        //}

        Debug.Log(currentRewardID); // 6001 이어야 됨 

        var rewardData = DataManager.Instance.Object.GetObjectid(currentRewardID);

        Debug.Log(rewardData.item.Count);
        List<int> itemList = rewardData.item; 
        List<int> itemCountList = rewardData.itemCount;

        for (int i = 0; i < itemList.Count; i++)
        {
            int itemID = itemList[i];
            int itemCount = itemCountList[i];

            var itemData = DataManager.Instance.Item.GetItemData(itemID);

            GameObject itemPrefab = Resources.Load<GameObject>("UI/RewardItem");
            GameObject itemInstance = Instantiate(itemPrefab, _itemListPanel.transform);

            TextMeshProUGUI itemNameText = itemInstance.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI itemCountText = itemInstance.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();

            itemNameText.text = itemData.displayName;
            itemCountText.text = itemCount.ToString();

            // 인벤토리 프리펩을 가져와서 쓰고 
            // 아이템 셀을 리소스 로드해서 불러와 서 
        }
    }
}

