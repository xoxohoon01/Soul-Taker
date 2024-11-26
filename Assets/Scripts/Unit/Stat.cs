using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public float CurrentValue
    {
        get
        {
            return ((originalValue + addition.Sum() - subtraction.Sum()) * (1 + (multiplier.Sum() / 100)));
        }
    } // 스텟 변경사항이 적용된 현재 값

    public float originalValue; // 원래의 스텟 (캐릭터 종류, 레벨에 의한 스텟)

    // 버프나 장비에 의해 변경되는 값
    public List<float> addition = new List<float>();    // 추가량
    public List<float> subtraction = new List<float>(); // 감소량
    public List<float> multiplier = new List<float>();  // 증가량
}
