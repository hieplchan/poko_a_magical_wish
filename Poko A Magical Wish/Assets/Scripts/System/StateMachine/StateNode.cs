using System.Collections.Generic;

public class StateNode {
    public IState State { get; }
    public HashSet<Transition> Transitions { get; }

    public StateNode(IState state) {
        State = state;
        Transitions = new HashSet<Transition>();
    }

    public void AddTransition(Transition transition) {
        Transitions.Add(transition);
    }
}
