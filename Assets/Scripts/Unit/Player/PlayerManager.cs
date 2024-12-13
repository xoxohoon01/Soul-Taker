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
        SpawnPlayer(Vector3.zero);
    }

    public void SpawnPlayer(Vector3 spawnPoint)
    {
        player = Instantiate(playerPrefab, spawnPoint, Quaternion.Euler(0, 0, 0)).GetComponent<Player>();
        player.status.InitializeStatus(DataManager.Instance.Character.GetCharacterid(1));
        player.GetComponent<PlayerInput>().ConnectJoyStick();

        Camera.main.transform.position = player.transform.position + new Vector3(0, 6, -8);
    }
}
