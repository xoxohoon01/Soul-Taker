using UnityEngine;
using System;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int roomId; // 해당 Room ID
    [SerializeField] private SpawnSystem[] spawners;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어와 닿았다!");
            spawners = FindObjectsOfType<SpawnSystem>();
            Debug.Log(spawners.Length); // 잘 됨. 

            foreach (var spawner in spawners)
            {
                if (spawner.GetRoomId() == roomId)
                {
                    spawner.ActivateSpawner();
                }
            }
        }
    }

}

