using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLv;
    [SerializeField] private TextMeshProUGUI textEnhance;
    [SerializeField] private TextMeshProUGUI textCount;

    private ItemInstance _item;
    
    private ItemDescription _itemDescription;
    
    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
    }

    private void Refresh()      //Update UI
    {
        if (DataManager.Instance.Item.GetItemData(_item.itemId).itemType != ItemType.Consumption && DataManager.Instance.Item.GetItemData(_item.itemId).itemType != ItemType.Misc)
        {
            Equipment();
        }
        else
        {
            ConsumptionMisc();
        }
    }
    
    private void Equipment()
    {
        //textLv.text = _item
        textEnhance.text = _item.enhance == 0 ? "" : $"+ {_item.enhance}";
    }

    private void ConsumptionMisc()
    {
        textCount.text = _item.count.ToString();
    }

    public void OnClick()
    {
        _itemDescription = UIManager.Instance.Show<ItemDescription>();
        _itemDescription.GetComponent<ItemDescription>().Initialize(_item);
    }
}
