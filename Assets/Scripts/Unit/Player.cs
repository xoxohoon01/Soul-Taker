using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Character Character;
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
