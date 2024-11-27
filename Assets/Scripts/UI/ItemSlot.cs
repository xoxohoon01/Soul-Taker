using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;
    public UIInventory uiInventory;
    public Button button;
    public Image icon;
    public TextMeshProUGUI quatityText;
    
    public int index;           //몇번째 아이템 슬롯인지 확인하는 번호
    public bool equipped;       //장착확인
    public int quantity;        //갯수

    public void Set()               //슬롯에 아이템 추가
    {
        icon.gameObject.SetActive(true);                            //슬롯에 아이템 아이콘 이미지 추가/ 추가안했을때에는 뒷배경이 나오므로 끄기
        //icon.sprite = item.icon;                                  //-----------아이콘 JSON에서 가져올때 어떻게 가져오는지 알기 / 리소스에서 가져온다고했는데... JSON에 어떻게 접근하는지도 몰라서 ㅎㅎ..
        quatityText.text = quantity > 1 ? quantity.ToString() : string.Empty;           //아이템 갯수넣는 텍스트
    }

    public void Clear()             //슬롯에 아이템 삭제 혹은 사용
    {
        item = null;
        icon.gameObject.SetActive(false);
        quatityText.text = string.Empty;
    }

    public void OnClickButton()
    {
        uiInventory.SelectItem(index);
    }
}
