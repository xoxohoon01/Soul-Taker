using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string Name;
    public string Descriptionn;
    public List<string> Requirements;
    public List<string> Requirements_Value;
    public List<string> Contents;
    public List<string> Contents_Value;
    public float Rewards_EXP;
    public int Rewards_Gold;
    public List<string> Rewards_Items;
}
