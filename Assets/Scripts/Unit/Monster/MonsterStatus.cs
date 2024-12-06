using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class MonsterStatus : Status
{
    public float Level;

    public void InitializeCurrentValue()
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
