public partial class PlayerControllerComponent {
    private StateMachine _stateMachine;

    private void AddAnyState(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);
    private void AddState(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);

    private void SetupStateMachine() {
        _stateMachine = new StateMachine();

        // define states
        LocomotionState locomotionState = new(player);

        // add states
        AddAnyState(locomotionState, new FuncPredicate(BackToLocomotionStateCondition));

        // init state
        _stateMachine.SetState(locomotionState);
    }

    private bool BackToLocomotionStateCondition() {
        return true;
    }
}
