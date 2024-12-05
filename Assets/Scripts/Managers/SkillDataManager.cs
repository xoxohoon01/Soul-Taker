using DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataManager : SkillData
{
    public List<SkillData> GetSkillList()
    {
        return SkillDataList;
    }

    public SkillData GetSkill(int id)
    {
        return SkillDataMap[id];
    }
}
