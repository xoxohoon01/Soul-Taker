using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeapon : MonoBehaviour
{
    protected Collider myCollider;
    protected float damage;

    protected void Start()
    {
        myCollider = GetComponent<Collider>();
        myCollider.enabled = false;
    }

    public virtual void UseWeapon(float damage)
    {
        this.damage = damage;
        myCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Status status = other.GetComponent<Status>();
            status.HP.CurrentValue -= Mathf.Max((damage - status.Defense.GetValue()) * Random.Range(0.9f, 1.1f), damage * 0.2f);
            myCollider.enabled = false;
        }
    }
}
