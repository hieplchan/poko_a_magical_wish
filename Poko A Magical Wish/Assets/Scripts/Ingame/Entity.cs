using KBCore.Refs;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    public enum EntityTag : int {
        NONE = 0,
        PLAYER = 1,
        ENEMY = 2
    }

    [SerializeField] public EntityTag Tag;
    [SerializeField, Child] public Rigidbody RbComp;
    [SerializeField, Self] public HealthComponent HealthComp;

    private void OnValidate() {
        var currComp = gameObject.GetComponent<HealthComponent>();
        if (this is IDamageable) {
            if (!currComp) {
                HealthComp = gameObject.AddComponent<HealthComponent>();
            } else {
                HealthComp = currComp;
            }
        } else {
            if (currComp) {
                DestroyImmediate(HealthComp);
            }
            HealthComp = null;
        }

        this.ValidateRefs();
    }
}
