using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Collider weaponCollider;
    [SerializeField] private Collider myCollider;

    private float damage;

    private void Awake()
    {
        weaponCollider = GetComponent<Collider>();
        weaponCollider.enabled = false;
    }

    private void Start()
    {
        myCollider = CharacterManager.Instance.Player.GetComponent<Collider>();
    }

    public void UseWeapon()
    {
        StartCoroutine(Use());
    }

    IEnumerator Use()
    {
        weaponCollider.enabled = true;
        Debug.Log("enable weapon");
        yield return null;

        while (true)
        {
            if (!CharacterManager.Instance.Player.Behavior.stateMachine.IsAttacking)
            {
                weaponCollider.enabled = false;
                Debug.Log("disable weapon");
                break;
            }
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;

        if (other.TryGetComponent(out Health health))
        {
            damage = CharacterManager.Instance.Player.Status.Damage.CurrentValue;
            health.TakeDamage(damage);

            Debug.Log("success attack");
        }
    }
}
