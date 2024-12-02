using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public GameObject playerPrefab;
    public Player player;

    private void Start()
    {
        player = Instantiate(playerPrefab).GetComponent<Player>();
        player.status.InitializeStatus(DatabaseManager.Instance.Character.GetCharacterid(1));
    }
}
