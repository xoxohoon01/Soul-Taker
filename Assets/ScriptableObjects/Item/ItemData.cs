using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public Sprite icon;
    
    public int itemId;
    public string ItemName;
    public string Description;
    public float Damage;
    public float AttackSpeed;
    public int Price;
    public int MaxAmount;

    public void SetId(int index)
    {
        itemId = index;
    }
}
