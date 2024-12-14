using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI textLv;
    [SerializeField] private TextMeshProUGUI textEnhance;
    [SerializeField] private TextMeshProUGUI textCount;

    private ItemInstance _item;
    private ItemInstance _rewarditem;

    private int _type;
    
    private ItemDescription _itemDescription;

    public void Initialize(ItemInstance item, int type)
    {
        _item = item;
        _type = type;

        Refresh();
    }

    private void Refresh()      //Update UI
    {
        ItemGradeColor();
        
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
        icon.sprite = SpriteManager.Instance.SpriteReturn(DataManager.Instance.Item.GetItemData(_item.itemId).icon);
        textEnhance.text = _item.enhance == 0 ? "" : $"+ {_item.enhance}";
    }

    private void ConsumptionMisc()
    {
        textCount.text = _item.count.ToString();
        Debug.Log(textCount.text);
    }

    public void OnClick()
    {
        _itemDescription = UIManager.Instance.Show<ItemDescription>();
        _itemDescription.GetComponent<ItemDescription>().Initialize(_item, _type);
    }

    private void ItemGradeColor()
    {
        switch (_item.gradeType)
        {
            case ItemGradeType.Normal:
                backGround.color = Color.white;
                break;
            case ItemGradeType.Uncommon:
                backGround.color = Color.green;
                break;
            case ItemGradeType.Rare:
                backGround.color = Color.blue;
                break;
            case ItemGradeType.Legend:
                backGround.color = Color.yellow;
                break;
        }
    }
}
