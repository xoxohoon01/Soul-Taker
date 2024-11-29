using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class Player : MonoBehaviour
{
    public CharacterData Character;
    public PlayerStatus Status;
    public PlayerBehavior Behavior;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        Status = GetComponent<PlayerStatus>();
        Behavior = GetComponent<PlayerBehavior>();
    }

    private void Start()
    {
        if (Character != null)
        {
            Status.InitializeStatus(Character);
        }
    }
}
