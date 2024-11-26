using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public string Description;
    public float Damage;
    public float AttackSpeed;
    public int Price;
    public int MaxAmount;
}
