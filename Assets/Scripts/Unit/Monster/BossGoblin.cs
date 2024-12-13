using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGoblin : Monster
{
    public override void SelectSkillIndex()
    {
        skillIndex = 0;
        if (status.HP.CurrentValue < maxHP * 0.5f)
        {
            skillIndex = 3;
        }
    }
}
