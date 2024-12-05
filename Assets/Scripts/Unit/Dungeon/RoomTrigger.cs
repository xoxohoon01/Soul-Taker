using UnityEngine;
using System;
using System.Collections.Generic;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int roomId;

    private bool isTrigger;
    //public List<RoomCollider> rooms;
    //private void Awake()
    //{
    //    rooms = new List<RoomCollider>(GetComponentsInChildren<RoomCollider>());
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTrigger)
        {
            DungeonManager.Instance.RoomEnter(roomId);
            //DungeonManager.Instance.roomColliders = rooms.ToArray();
            isTrigger = true;
        }
    }
}

