using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;
    public UIInventory inventory;
    public Button button;
    public Image icon;
    public TextMeshProUGUI quatityText;
    private Outline outline;
    
    public int index;           //몇번째 아이템 슬롯인지 확인하는 번호
    public bool equipped;       //장착확인
    public int quantity;        //갯수
    
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        //icon.sprite = item.icon;                                  //-----------아이콘 JSON에서 가져올때 어떻게 가져오는지 알기 / 리소스에서 가져온다고했는데... JSON에 어떻게 접근하는지도 몰라서 ㅎㅎ..
        quatityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if(outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quatityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        inventory.SelectItem(index);
    }
}
