using UnityEngine;
using System;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int roomId;
    private bool isTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTrigger)
        {
            DungeonManager.Instance.RoomEnter(roomId);
            isTrigger = true;
        }
    }
}

