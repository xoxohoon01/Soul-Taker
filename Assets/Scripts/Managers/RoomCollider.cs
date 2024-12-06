using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    private int RoomColliderID;
    public int GetRoomColliderID() => RoomColliderID;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}

