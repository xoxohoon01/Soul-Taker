using System;
using UnityEngine;

[Serializable]
public enum ItemType
{
    Equipable,              //장비 아이템
    Consumable,              //소비 아이템
    QuestItem               // 퀘스트 아이템
}

[Serializable]
public enum ConsumableType
{
    Hunger,                     //추후 HP, MP 물약으로 변경예정
    Health
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;         //소모품의 타입
    public float value;                 //소모품 회복시킬 양
}


public class ItemData
{
    public string Icon = "Sprites/Square";     //아이템 이미지는 리소스폴더에서 이미지를 가져오는방식
    
    public int itemId;                              //아이템 넘버
    public string displayName;                      //아이템 이름
    public string description;                      //아이템 설명
    public ItemType Type;                           //아이템 타입(장비, 소비, 퀘스트)
    public float Damage;                            //공격력
    public float AttackSpeed;                       //공격속도
    public int Price;                               //가격
    
    [Header("Stacking")]
    public bool canStack;                           //여러개 가지는 아이템인지 체크하는 변수
    public int maxStackAmount;                      //최대 갯수
    
    [Header("Consumable")]
    public ItemDataConsumable[] consumables;        //소모탬 타입

    public void SetId(int index)
    {
        itemId = index;
    }
}
//string : 파일명만 확실하게 해놓으면 파일이 변해도 아이템을 가져올 수 있다.
//int : 인덴싱을 사용해서 편하다. 단 JSON에서 데이터를 가져올려면 정보를 일일이 확인해야한다.......