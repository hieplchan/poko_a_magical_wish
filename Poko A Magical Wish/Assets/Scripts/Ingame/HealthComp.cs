using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComp : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int CurrHealth { get; private set; }

    [SerializeField] public UnityEvent<int> HealthChanged;

    void Awake()
    {
        CurrHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrHealth -= damage;
        HealthChanged?.Invoke(CurrHealth);
    }

    public bool IsDead() => CurrHealth <= 0;
}
