using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] slots;
    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Inventory inventory;
    
    private ItemData selectedItem;          //클릭된 아이템에 대한 정보
    private int selectedItemIndex = 0;          //클릭된 아이템의 갯수
    
    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;
    
    public void Toggle()            //인벤토리 키 눌렀을때 인벤토리 나오게 하는 함수
    {
        if (IsOpen())
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }
    
    public void UpdateUI()          //인벤토리 UI 업데이트하기
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
    
    public void SelectItem(int index)               //지금 슬롯의 인덱스가 몇번인지를 매개변수로 받아와서 클릭했을떄 아이템 정보들 출력
    {
        if (slots[index].item == null) return;

        selectedItem = slots[index].item;
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.displayName;
        selectedItemDescription.text = selectedItem.description;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        for(int i = 0; i< selectedItem.consumables.Length; i++)
        {
            selectedItemStatName.text += selectedItem.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.consumables[i].value.ToString() + "\n";
        }
        
        //아이템의 타입에 따라서 어떤 버튼을 킬지 결정되는곳/ 타입마다 UI창 다르게 하는것도 여기서 작성할 것
        useButton.SetActive(selectedItem.Type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.Type == ItemType.Equipable && !slots[index].equipped);
        unEquipButton.SetActive(selectedItem.Type == ItemType.Equipable && slots[index].equipped);
        dropButton.SetActive(true);
    }

    private void ClearSelectedItemWindow()
    {
        selectedItem = null;

        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void OnUseButton()           //소비 아이템 사용 버튼
    {
        if(selectedItem.Type == ItemType.Consumable)
        {
            for(int i = 0; i < selectedItem.consumables.Length; i++)
            {
                switch (selectedItem.consumables[i].type)
                {
                    case ConsumableType.Health:
                        //condition.Heal(selectedItem.item.consumables[i].value); break;
                    case ConsumableType.Hunger:
                        //condition.Eat(selectedItem.item.consumables[i].value);break;
                        break;
                }
            }
            RemoveSelctedItem();
        }
    }

    public void OnDropButton()          //아이템 파괴
    {
        //inventory.RemoveItem();           //강의에서는 여기서 아이템 버리는 함수 사용
        //inventory.RemoveItem(selectedItem);       //이런거 필요없이 밑에 코드한줄만 있으면 될거 같은데... 그래서 RemoveItem함수 주석처리
        RemoveSelctedItem();
    }

    private void RemoveSelctedItem()        //아이템 파괴했을때 UI정보들을 사라지게하기
    {
        slots[selectedItemIndex].quantity--;            //지금은 ItemSlot에 저장되어 있는 갯수로 판별하지만 나중에는 ItemData에 저장되어 있는 갯수로 판단할것

        if(slots[selectedItemIndex].quantity <= 0)
        {
            selectedItem = null;
            slots[selectedItemIndex].item = null;       //인벤토리 UI아이템 사라지게하는 코드
            selectedItemIndex = -1;
            ClearSelectedItemWindow();
        }

        UpdateUI();
    }

    public bool HasItem(ItemData item, int quantity)
    {
        return false;
    }
}
