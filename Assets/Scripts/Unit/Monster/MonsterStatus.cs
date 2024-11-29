using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MonsterStatus : Status
{
    public float Level;
    public float EXP;

    public float AttackRange;
    public float DetectRange;

    public void InitializeStatus(MonsterData monsterData)
    {
        HP.originalValue = monsterData.HP;
        MP.originalValue = monsterData.MP;
        Damage.originalValue = monsterData.Damage;
        Defense.originalValue = monsterData.Defense;
        MoveSpeed.originalValue = monsterData.MoveSpeed;
        AttackSpeed.originalValue = monsterData.AttackSpeed;
        HPRegeneration.originalValue = monsterData.HPRegeneration;
        MPRegeneration.originalValue = monsterData.MPRegeneration;
    }
}
