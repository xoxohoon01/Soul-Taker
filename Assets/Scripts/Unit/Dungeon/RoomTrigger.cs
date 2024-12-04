using UnityEngine;
using System;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int roomId; // 해당 Room ID
    [SerializeField] private Spawner[] spawners;

    private void OnTriggerEnter(Collider other)
    {
        // 닿으면 던전 매니저에서 플레이어가 닿았다는 정보를 알려줘서 스포너가 스폰하라고 알려준다

        if (other.CompareTag("Player"))
        {
            //spawners = FindObjectsOfType<Spawner>();

            DungeonManager.Instance.EnterRoom(roomId);

        }
    }

}

