using System.Collections;
using System.Collections.Generic;
using KBCore.Refs;
using UnityEngine;

public class Player : Entity
{
    [SerializeField, Self] public PlayerController Controller;
}
