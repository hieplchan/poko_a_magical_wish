using System;
using KBCore.Refs;
using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour {
    [SerializeField, Self] private readonly Rigidbody rbBody;
    [SerializeField, Anywhere] private readonly InputReader input;

    public Vector3 Movement { get; private set; }

    private Transform mainCameraTransform;

    private void OnEnable() {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update() {
        Movement = new Vector3(input.Direction.x, 0, input.Direction.y);
    }
}
