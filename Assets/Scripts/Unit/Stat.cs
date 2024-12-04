using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float currentValue;
    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
        }
    }

    public float originalValue; // 원래의 스텟 (캐릭터 종류, 레벨에 의한 스텟)

    // 버프나 장비에 의해 변경되는 값
    public List<float> addition = new List<float>();    // 추가량
    public List<float> subtraction = new List<float>(); // 감소량
    public List<float> multiplier = new List<float>();  // 증가량

    public float GetValue()
    {
        return ((originalValue + addition.Sum() - subtraction.Sum()) * (1 + (multiplier.Sum() / 100)));
    }
}
