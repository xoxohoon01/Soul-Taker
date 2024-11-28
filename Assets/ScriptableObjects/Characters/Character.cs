using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class Character
{
    public float HP;
    public float MP;
    public float Damage;
    public float Defense;
    public float MoveSpeed;
    public float AttackSpeed;
    public float HPRegeneration;
    public float MPRegeneration;
    public float DrainLife;

    public float HPPerLevel;
    public float MPPerLevel;
    public float DamagePerLevel;
    public float DefensePerLevel;
    public float HPRegenerationPerLevel;
    public float MPRegenerationPerLevel;
}
