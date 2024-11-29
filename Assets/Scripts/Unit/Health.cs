using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        maxHealth = GetComponent<Status>().HP.CurrentValue;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth == 0)
        {
            //Die();
        }

        currentHealth = Mathf.Max(currentHealth - damage, 0f);
    }
}
