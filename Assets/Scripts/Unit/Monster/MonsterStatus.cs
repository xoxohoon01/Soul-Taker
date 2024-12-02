using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class MonsterStatus : Status
{
    public float Level;
    public float AttackRange;
    public float DetectRange;
    public float FieldOfView;

    public void InitializeStatus(MonsterData monsterData)
    {
        HP.originalValue = monsterData.HP + monsterData.HPPerLevel * Level;
        MP.originalValue = monsterData.MP + monsterData.MPPerLevel * Level;
        Damage.originalValue = monsterData.Damage + monsterData.DamagePerLevel * Level;
        Defense.originalValue = monsterData.Defense + monsterData.DefensePerLevel * Level;
        MoveSpeed.originalValue = monsterData.MoveSpeed;
        AttackSpeed.originalValue = monsterData.AttackSpeed;
        HPRegeneration.originalValue = monsterData.HPRegeneration + monsterData.HPRegenerationPerLevel * Level;
        MPRegeneration.originalValue = monsterData.MPRegeneration + monsterData.MPRegenerationPerLevel * Level;
        AttackRange = monsterData.AttackRange;
        DetectRange = monsterData.DetectRange;
        FieldOfView = monsterData.FieldOfView;
    }

    public void InitializeLevel(int level)
    {
        Level = level;
    }
}
