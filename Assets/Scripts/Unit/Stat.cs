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
    } // ���� ��������� ����� ���� ��

    public float originalValue; // ������ ���� (ĳ���� ����, ������ ���� ����)

    // ������ ��� ���� ����Ǵ� ��
    public List<float> addition = new List<float>();    // �߰���
    public List<float> subtraction = new List<float>(); // ���ҷ�
    public List<float> multiplier = new List<float>();  // ������
}
