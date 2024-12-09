using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : UIBase
{
    private ItemInstance _item;
    
    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
        ButtonInitialize();
    }
    
    private void Refresh()      //Update UI
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = 
    }

    private void ButtonInitialize()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => UIManager.Instance.Show<ItemDescription>().Initialize(_item));
    }
}
