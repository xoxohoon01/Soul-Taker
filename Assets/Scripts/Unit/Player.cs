using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public Character character;

    public float Level;
    public float EXP;

    protected new void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        if (character != null)
        {
            status.HP.originalValue = character.HP;
            status.MP.originalValue = character.MP;
            status.Damage.originalValue = character.Damage;
            status.Defense.originalValue = character.Defense;
            status.MoveSpeed.originalValue = character.MoveSpeed;
            status.AttackSpeed.originalValue = character.AttackSpeed;
            status.HPRegeneration.originalValue = character.HPRegeneration;
            status.MPRegeneration.originalValue = character.MPRegeneration;
        }
    }
}
