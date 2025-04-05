using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour {
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int CurrHealth { get; private set; }

    public UnityEvent<int> HealthChanged;

    private void Awake() => CurrHealth = MaxHealth;

    public void TakeDamage(int damage) {
        CurrHealth -= damage;
        HealthChanged?.Invoke(CurrHealth);
    }

    public bool IsDead() => CurrHealth <= 0;
}
