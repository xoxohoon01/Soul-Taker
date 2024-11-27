using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{ 
    public UIInventory uiInventory;

    private void Start()
    {
        uiInventory.gameObject.SetActive(false);
        uiInventory.slots = new ItemSlot[uiInventory.slotPanel.childCount];     //자식들의 개수만큼 슬롯 생성

        for (int i = 0; i < uiInventory.slots.Length; i++)
        {
            uiInventory.slots[i] = uiInventory.slotPanel.GetChild(i).GetComponent<ItemSlot>();
            uiInventory.slots[i].index = i;
            uiInventory.slots[i].uiInventory = uiInventory;
        }
    }
    
    public void AddItem()      //아이템 추가
    {
        //ItemData data = CharacterManager.Instance.Player.itemData;    //아이템 데이터 받아오기-----------------어케함??
        ItemData data = new ItemData();         //오류뜨는거 임시로 막아두기 아이템 데이터 받아오면 이 코드 지우기 ----------------------------
        if (data.canStack)
        {
            ItemSlot slot = GetItemStack(data);
            if(slot != null)
            {
                slot.quantity++;
                uiInventory.UpdateUI();
                //CharacterManager.Instance.Player.itemData = null;     아이템을 가져왔으니 다시 지운다
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if(emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            uiInventory.UpdateUI();
            //CharacterManager.Instance.Player.itemData = null;
            return;
        }

        WarnInventoryFull();
        //CharacterManager.Instance.Player.itemData = null;
    }

    public void RemoveItem(ItemData data)       //아이템 파괴 어떻게 시키지???
    {
        /*
        if (index >= 0 && index < uiInventory.slots.Length)
        {
            uiInventory.slots[index].item = null;
            uiInventory.UpdateUI();
        }
        */      //Destroy(data); 사용해서 아이템 지울려니깐 매개변수 타입이 Object여서 안되네...
    }
    
    private ItemSlot GetItemStack(ItemData data)            //소모품 중복 슬롯 찾기
    {
        for(int i = 0; i < uiInventory.slots.Length; i++)
        {
            if (uiInventory.slots[i].item == data && uiInventory.slots[i].quantity < data.maxStackAmount)
            {
                return uiInventory.slots[i];
            }
        }
        return null;
    }

    private ItemSlot GetEmptySlot()                         //비어있는 슬롯 가져오기 
    {
        for(int i = 0; i < uiInventory.slots.Length; i++)
        {
            if (uiInventory.slots[i].item == null)
            {
                return uiInventory.slots[i];
            }
        }
        return null;
    }

    private void WarnInventoryFull()                //아이템 슬롯이 꽉 찼을시 보내는 문구
    {
        Debug.Log("아이템 슬롯이 가득찼습니다");            //빈 슬롯이 없으니 안내문구를 보낸다.
    }
}