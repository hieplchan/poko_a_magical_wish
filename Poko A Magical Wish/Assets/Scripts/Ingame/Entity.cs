using System.Collections;
using System.Collections.Generic;
using KBCore.Refs;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField, Child] public Rigidbody Rigidbody;
    [SerializeField, Self] public HealthComp HealthComp;

#if UNITY_EDITOR
    void OnValidate()
    {
        this.ValidateRefs();
    }
#endif
}
