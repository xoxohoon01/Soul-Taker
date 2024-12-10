using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIReward : UIBase
{
    // 개별 아이템 프리펩에 들어갈 정보 
    private Image _itemImage;
    private int _itemCount; 
    private TextMeshProUGUI _itemTxt;

    private GameObject _itemListPanel;
    private GameObject[] _itemList; // 상자에 있는 모든 아이템 

    private void Awake()
    {
        
    }

    private void ShowDisplay()
    {
        GameObject item = Resources.Load<GameObject>("RewardItem");

        for (int i = 0; i < _itemList.Length; i++) // 상자 속 아이템 수만큼 아이템 생성 
        {
            Instantiate(item, _itemListPanel.transform);
            
            //_itemList = DataManager.Instance.Item.GetItemData();

        }

    }

}

