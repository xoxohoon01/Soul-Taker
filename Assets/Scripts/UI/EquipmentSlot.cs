using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image equipment;
    
    private ItemInstance _item;
    
    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
    }
    
    private void Refresh()      //Update UI
    {
        //equipment.sprite = _item
    }
}
