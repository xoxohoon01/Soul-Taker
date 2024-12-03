using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private TextMeshProUGUI textEnhance;

    private ItemInstance _item;
    
    public void Initialize(ItemInstance item)
    {
        _item = item;
        
        Refresh();
    }

    private void Refresh()      //Update UI
    {
        textCount.text = _item.count.ToString();
        textEnhance.text = _item.enhance.ToString();
    }
}
