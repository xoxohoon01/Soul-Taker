using System.Collections;
using System.Collections.Generic;
using DataTable;
using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDescription;
    
    private ItemInstance _item;

    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
    }

    private void Refresh()
    {
        ItemData data = DataManager.Instance.Item.GetItemData(_item.itemId);
        textName.text = data.DisplayName;
        textDescription.text = data.Description;
    }

    public void OnClick()
    {
        gameObject.SetActive(false);
    }
}
