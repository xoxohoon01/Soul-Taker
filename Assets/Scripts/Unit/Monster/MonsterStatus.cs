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
    public float MinWanderDistance;
    public float MaxWanderDistance;
    public float WanderRate;

    public void InitializeStatus(MonsterData monsterData)
    {
        Level = monsterData.level;
        HP.originalValue = monsterData.hp + monsterData.hpPerLevel * Level;
        MP.originalValue = monsterData.mp + monsterData.mpPerLevel * Level;
        Damage.originalValue = monsterData.damage + monsterData.damagePerLevel * Level;
        Defense.originalValue = monsterData.defense + monsterData.defensePerLevel * Level;
        MoveSpeed.originalValue = monsterData.moveSpeed;
        AttackSpeed.originalValue = monsterData.attackSpeed;
        HPRegeneration.originalValue = monsterData.hpRegeneration + monsterData.hpRegenerationPerLevel * Level;
        MPRegeneration.originalValue = monsterData.mpRegeneration + monsterData.mpRegenerationPerLevel * Level;
        AttackRange = monsterData.attackRange;
        DetectRange = monsterData.detectRange;
        FieldOfView = monsterData.fieldOfView;
        //MinWanderDistance = monsterData.minWanderDistance;
        //MaxWanderDistance = monsterData.maxWanderDistance;
        //WanderRate = monsterData.wanderRate;
    }
}
