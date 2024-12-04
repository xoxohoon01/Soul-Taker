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
    
    private GameObject _itemExplanation;
    
    public void Initialize(ItemInstance item, GameObject itemExplanation)
    {
        _item = item;
        _itemExplanation = itemExplanation;
        
        Refresh();
    }

    private void Refresh()      //Update UI
    {
        textCount.text = _item.count.ToString();
        textEnhance.text = _item.enhance.ToString();
    }

    public void OnClick()
    {
        _itemExplanation.SetActive(true); 
        _itemExplanation.GetComponent<ItemDescription>().Initialize(_item);
    }
}
