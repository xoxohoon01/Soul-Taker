using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public event Action OnDie;

    private void Start()
    {
        maxHealth = GetComponent<Status>().HP.CurrentValue;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0f);

        if (currentHealth == 0)
        {
            OnDie?.Invoke();
        }
    }
}
