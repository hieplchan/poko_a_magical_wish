using System.Collections;
using System.Collections.Generic;
using KBCore.Refs;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public enum EntityTag : int
    {
        NONE = 0,
        PLAYER = 1,
        ENEMY = 2
    }

    [field: SerializeField] public EntityTag Tag { get; private set; }
    [SerializeField, Child] public Rigidbody RbComp;
    [SerializeField, Self] public HealthComponent HealthComp = null;

    void OnValidate()
    {
        var currComp = gameObject.GetComponent<HealthComponent>();
        if (this is IDamageable)
        {
            if (!currComp) 
            {
                HealthComp = gameObject.AddComponent<HealthComponent>();
            }
            else 
            {
                HealthComp = currComp;
            }
        }
        else
        {
            if (currComp)
            {
                DestroyImmediate(HealthComp);
            }
            HealthComp = null;
        }

        this.ValidateRefs();
    }
}
