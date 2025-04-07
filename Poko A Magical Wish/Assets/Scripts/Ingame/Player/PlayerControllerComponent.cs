using System;
using KBCore.Refs;
using UnityEngine;
using UnityEngine.XR;

public partial class PlayerControllerComponent : MonoBehaviour {
    [SerializeField, Self] private Player player;
    [SerializeField] private InputReader input;

    private Rigidbody _rb => player.RbComp;
    private Animator _animator => player.AnimatorComp;

    [Header("Movement Settings")]
    [SerializeField] private float _walkSpeed = 150f;

    public Vector3 Movement { get; private set; }

    private Transform _mainCameraTransform;

    #region Unity Functions
    private void Awake() {
        SetupTimers();
        SetupStateMachine();
    }

    private void OnEnable() {
        _mainCameraTransform = Camera.main.transform;
    }

    private void Update() {
        Movement = new Vector3(input.Direction.x, 0, input.Direction.y);

        _stateMachine.Update();
        HandleTimers();

        UpdateAnimator();
    }

    private void FixedUpdate() {
        _stateMachine.FixedUpdate();
    }
    #endregion

    #region Movement
    public void HandleMovement() {
        // rotate movement vector to camera direction
        var adjustedDirection = Quaternion.AngleAxis(_mainCameraTransform.eulerAngles.y, Vector3.up) * Movement;

        if (adjustedDirection.magnitude > 0f) {
            HandleHorizontalMovement(adjustedDirection);
        } else {
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
    }

    private void HandleHorizontalMovement(Vector3 adjustedDirection) {
        float speed = _walkSpeed;

        var velocity = speed * Time.fixedDeltaTime * adjustedDirection;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
    }

    private void UpdateAnimator() {
        _animator.SetFloat(PlayerAnimHash.Speed, _rb.velocity.magnitude);
    }
    #endregion
}
