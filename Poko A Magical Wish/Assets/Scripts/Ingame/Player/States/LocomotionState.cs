public sealed class LocomotionState : PlayerBaseState {
    public LocomotionState(Player player) : base(player) {
    }

    public override void OnEnter() {
        MLog.Debug("LocomotionState", $"OnEnter");
        _animator.CrossFadeInFixedTime(PlayerAnimHash.Locomotion, CrossFadeDuration);
    }

    public override void Update() {

    }

    public override void FixedUpdate() {
        _controller.HandleMovement();
    }

    public override void OnExit() {
    }
}
