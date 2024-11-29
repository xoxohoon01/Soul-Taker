using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Monster : MonoBehaviour
{
    public MonsterStatus Status;
    public MonsterBehavior Behavior;

    private void Awake()
    {
        Status = GetComponent<MonsterStatus>();
        Behavior = GetComponent<MonsterBehavior>();
        Behavior.Status = Status;
    }
}
