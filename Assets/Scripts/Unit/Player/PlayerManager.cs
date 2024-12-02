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
        player.status.InitializeStatus(DataManager.Instance.Character.GetCharacterid(1));
    }
}
