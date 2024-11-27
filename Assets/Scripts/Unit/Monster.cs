using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Monster : Unit
{
    public float Level;
    public float EXP;

    protected new void Awake()
    {
        base.Awake();
    }

    public void InitMonster(MonsterData monsterData)
    {
        status.HP.originalValue = monsterData.HP;
        status.MP.originalValue = monsterData.MP;
        status.Damage.originalValue = monsterData.Damage;
        status.Defense.originalValue = monsterData.Defense;
        status.MoveSpeed.originalValue = monsterData.MoveSpeed;
        status.AttackSpeed.originalValue = monsterData.AttackSpeed;
        status.HPRegeneration.originalValue = monsterData.HPRegeneration;
        status.MPRegeneration.originalValue = monsterData.MPRegeneration;
    }
}
