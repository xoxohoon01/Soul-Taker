using UnityEngine;


public class RoomCollider : MonoBehaviour
{
    [SerializeField] private int RoomColliderID;
    public int GetRoomColliderID() => RoomColliderID;

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}

