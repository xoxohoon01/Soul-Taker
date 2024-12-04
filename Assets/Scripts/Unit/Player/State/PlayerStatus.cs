using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using DataTable;

public class PlayerStatus : Status
{
    public float Level;
    public float EXP;

    public void InitializeStatus(CharacterData character)
    {
        HP.originalValue = character.hp;
        MP.originalValue = character.mp;
        Damage.originalValue = character.damage;
        Defense.originalValue = character.defense;
        MoveSpeed.originalValue = character.moveSpeed;
        AttackSpeed.originalValue = character.attackSpeed;
        HPRegeneration.originalValue = character.hpRegeneration;
        MPRegeneration.originalValue = character.mpRegeneration;
    }

    public void EnterDungeon()
    {
        HP.CurrentValue = HP.GetValue();
        MP.CurrentValue = MP.GetValue();
        Damage.CurrentValue = Damage.GetValue();
        Defense.CurrentValue = Defense.GetValue();
        MoveSpeed.CurrentValue = MoveSpeed.GetValue();
        AttackSpeed.CurrentValue = AttackSpeed.GetValue();
        HPRegeneration.CurrentValue = HPRegeneration.GetValue();
        MPRegeneration.CurrentValue = MPRegeneration.GetValue();
    }
}
