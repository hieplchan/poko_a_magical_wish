public interface Transition {
    public IState To { get; }
    public IPredicate Condition { get; }
}
