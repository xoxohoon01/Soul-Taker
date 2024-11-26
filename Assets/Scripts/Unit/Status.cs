using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public Stat HP;
    public Stat MP;
    public Stat Damage;
    public Stat Defense;
    public Stat MoveSpeed;
    public Stat AttackSpeed;
    public Stat HPRegeneration;
    public Stat MPRegeneration;
    public Stat DrainLife;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(HP.CurrentValue);
        }
    }
}
