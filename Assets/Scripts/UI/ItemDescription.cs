using System.Collections;
using System.Collections.Generic;
using DataTable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : UIBase            //UIManager 통해 생성하기
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private TextMeshProUGUI textItemDescriptionTitle;
    [SerializeField] private Image itemImage;
    
    private ItemInstance _item;

    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
    }

    private void Refresh()
    {
        ItemData data = DataManager.Instance.Item.GetItemData(_item.itemId);
        textName.text = data.displayName;
        textDescription.text = data.description;
    }

    public void OnClick()
    {
        Hide();
    }
}
