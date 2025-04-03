using System;
using KBCore.Refs;
using UnityEngine;

public partial class PlayerControllerComponent : MonoBehaviour {
    [SerializeField, Self] private Player player;
    [SerializeField] private InputReader input;

    public Vector3 Movement { get; private set; }

    private Transform mainCameraTransform;

    private void Awake() {
        SetupStateMachine();
    }

    private void OnEnable() {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update() {
        Movement = new Vector3(input.Direction.x, 0, input.Direction.y);
    }

    public void HandleMovement() {

    }
}
