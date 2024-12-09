using System.Collections;
using System.Collections.Generic;
using DataTable;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : UIBase            //UIManager 통해 생성하기
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textDescription;
    [SerializeField] private TextMeshProUGUI textItemDescriptionTitle;
    [SerializeField] private Image itemImage;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button useButton;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unEquipButton;
    [SerializeField] private Button destructionButton;
    
    private ItemInstance _item;

    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
        ButtonInitialize();
    }

    private void Refresh()
    {
        ItemData data = DataManager.Instance.Item.GetItemData(_item.itemId);
        textName.text = data.displayName;
        textDescription.text = data.description;
    }
    
    private void ButtonInitialize()
    {
        closeButton.onClick.AddListener(() => Hide());
        //useButton.onClick.AddListener(() => );
        //equipButton.onClick.AddListener(() => );
        //unEquipButton.onClick.AddListener(() => );
        destructionButton.onClick.AddListener(() =>
        {
            ItemManager.Instance.DeleteItem(_item.id);
            Hide();
            HUD.Instance.OnInventory();
        } );
    }
}
