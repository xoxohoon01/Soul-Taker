using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerStatus : Status
{
    public float Level;
    public float EXP;

    public void InitializeStatus(Character character)
    {
        HP.originalValue = character.HP;
        MP.originalValue = character.MP;
        Damage.originalValue = character.Damage;
        Defense.originalValue = character.Defense;
        MoveSpeed.originalValue = character.MoveSpeed;
        AttackSpeed.originalValue = character.AttackSpeed;
        HPRegeneration.originalValue = character.HPRegeneration;
        MPRegeneration.originalValue = character.MPRegeneration;
    }
}
