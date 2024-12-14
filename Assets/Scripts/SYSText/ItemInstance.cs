using System.Collections.Generic;

[System.Serializable]
public class ItemInstance
{
    public int id;          //서버에서 발급해주는 아이템 아이디
    public int itemId;      //기획 데이터에 있는 아이템 아이디
    public int count;
    public int enhance;     //강화 횟수
    public bool equip;      //아이템 장착
    public ItemGradeType gradeType;
}

public enum ItemGradeType
{
    Normal,
    Uncommon,
    Rare,
    Legend
}

[System.Serializable]
public class ItemInstanceData       //인스펙터창에 정보 표기하기 위해서 사용된 클래스
{
    public List<ItemInstance> itemInstances;
}
