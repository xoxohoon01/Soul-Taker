using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}

public enum ConsumableType
{
    Hunger,
    Health
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public Sprite icon;
    public GameObject dropPrefab;
    
    public int itemId;
    public string displayName;
    public string description;
    public ItemType Type;
    public float Damage;
    public float AttackSpeed;
    public int Price;
    public int MaxAmount;
    
    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
    
    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
    
    [Header("Equip")]
    public GameObject equipPrefab;

    public void SetId(int index)
    {
        itemId = index;
    }
}
