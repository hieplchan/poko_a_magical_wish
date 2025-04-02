using KBCore.Refs;
using UnityEngine;

public class Player : Entity, IDamageable {
    [SerializeField, Child] public Animator AnimatorComp;
    [SerializeField, Self] public PlayerControllerComponent ControllerComp;

    public void TakeDamage(int damage) => HealthComp.TakeDamage(damage);
}
