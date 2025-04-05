using UnityEngine;

public abstract class PlayerBaseState : IState {
    protected Player _player;

    protected float CrossFadeDuration = 0.1f;
    protected PlayerControllerComponent _controller => _player.ControllerComp;
    protected Animator _animator => _player.AnimatorComp;

    protected PlayerBaseState(Player player) {
        _player = player;
    }

    public virtual void OnEnter() {
        //noop
    }

    public virtual void Update() {
        //noop
    }

    public virtual void FixedUpdate() {
        //noop
    }

    public virtual void OnExit() {
        //noop
    }
}
