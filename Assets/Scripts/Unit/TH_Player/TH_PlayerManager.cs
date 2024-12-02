using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTable;

public class TH_PlayerManager : MonoSingleton<TH_PlayerManager>
{
    public GameObject playerPrefab;
    public TH_Player player;

    private void Start()
    {
        player = Instantiate(playerPrefab).GetComponent<TH_Player>();
        player.status.InitializeStatus(DatabaseManager.Instance.Character.GetCharacterid(1));
    }
}
