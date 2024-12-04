using UnityEngine;
using System;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int roomId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DungeonManager.Instance.EnterRoom(roomId);
        }
    }

}

