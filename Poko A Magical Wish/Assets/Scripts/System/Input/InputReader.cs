using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "System/InputReader")]
public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions {

    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction<bool> Dash = delegate { };
    public event UnityAction<bool> Shield = delegate { };
    public event UnityAction<bool> Confirm = delegate { };
    public event UnityAction<bool> Attack = delegate { };
    public event UnityAction<bool> Item1 = delegate { };
    public event UnityAction<bool> Item2 = delegate { };

    public Vector3 Direction => _inputActions.Player.Move.ReadValue<Vector2>();

    private PlayerInputActions _inputActions;

    private void OnEnable() {
        if (_inputActions == null) {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.SetCallbacks(this);
        }
        _inputActions.Enable();
    }

    private void OnDestroy() {
        _inputActions.Disable();
        _inputActions.Player.SetCallbacks(null);
    }

    public void OnMove(InputAction.CallbackContext context)
        => Move.Invoke(context.ReadValue<Vector2>());

    public void OnDash(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                Dash.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Dash.Invoke(false);
                break;
        }
    }

    public void OnShield(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                Shield.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Shield.Invoke(false);
                break;
        }
    }

    public void OnConfirm(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            Confirm.Invoke(true);
        }
    }

    public void OnAttack(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                Attack.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Attack.Invoke(false);
                break;
        }
    }

    public void OnItem1(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                Item1.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Item2.Invoke(false);
                break;
        }
    }

    public void OnItem2(InputAction.CallbackContext context) {
        switch (context.phase) {
            case InputActionPhase.Started:
                Item2.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Item2.Invoke(false);
                break;
        }
    }
}
