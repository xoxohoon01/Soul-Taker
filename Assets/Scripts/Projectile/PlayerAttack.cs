using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Vector3 size = new Vector3(1, 1, 1);
    public Vector3 offset = Vector3.zero;
    public Vector3 moveVector = Vector3.zero;
    public float lifeTime;

    private void Start()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        transform.localScale = size;
        transform.position = 
            transform.position + 
            (transform.right * offset.x) + 
            (transform.up * offset.y) + 
            (transform.forward * offset.z) + 
            (Vector3.up * (size.y / 2.0f));
    }

    private void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
