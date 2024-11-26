using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Character character;
    private Status status;

    public float Level;
    public float EXP;

    private void Awake()
    {
        status = GetComponent<Status>();
    }
    private void Start()
    {
        if (character != null)
        {
            status.HP.originalValue = character.HP;
            status.MP.originalValue = character.MP;
            status.Damage.originalValue = character.Damage;
            status.Defense.originalValue = character.Defense;
            status.MoveSpeed.originalValue = character.MoveSpeed;
            status.AttackSpeed.originalValue = character.AttackSpeed;
            status.HPRegeneration.originalValue = character.HPRegeneration;
            status.MPRegeneration.originalValue = character.MPRegeneration;
        }
    }
}
