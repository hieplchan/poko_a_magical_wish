using UnityEngine;

public abstract class EquipmentStrategy : ScriptableObject {
    [field: SerializeField] protected int Damage { get; private set; } = 10;

    public virtual void Initialize() {
        // noop
    }

    public abstract void Fire();
}
