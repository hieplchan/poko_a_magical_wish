using System;
using System.Collections.Generic;

public class StateMachine {
    private StateNode _currState;
    private readonly Dictionary<Type, StateNode> _nodes = new();
    private readonly HashSet<Transition> _anyTransitions = new(); // Transitions that can happen at any time

    public void Update() {
        var transition = GetTransition();
        if (transition != null) {
            ChangeState(transition.To);
        }

        _currState.State?.Update();
    }

    public void FixedUpdate() {
        _currState.State.FixedUpdate();
    }

    public void SetState(IState state) {
        _currState?.State.OnExit();

        _currState = _nodes[state.GetType()];
        _currState.State.OnEnter();
    }

    public void ChangeState(IState state) {
        if (state == _currState.State) {
            return;
        }
        SetState(state);
    }

    // Adds a transition between two states with a specified condition.
    public void AddTransition(IState from, IState to, IPredicate condition) {
        GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
    }

    public void AddAnyTransition(IState to, IPredicate condition) {
        _anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
    }

    #region Utils
    // Retrieves the existing StateNode for the given state
    // or creates and adds a new one if it doesn't exist.
    private StateNode GetOrAddNode(IState state) {
        var node = _nodes.GetValueOrDefault(state.GetType());
        if (node == null) {
            node = new StateNode(state);
            _nodes.Add(state.GetType(), node);
        }
        return node;
    }

    // Evaluates and retrieves the first valid transition based on the conditions.
    private Transition GetTransition() {
        // _anyTransitions is checked first, as it can happen at any time
        foreach (var transition in _anyTransitions) {
            if (transition.Condition.Eval()) {
                return transition;
            }
        }

        foreach (var transition in _currState.Transitions) {
            if (transition.Condition.Eval()) {
                return transition;
            }
        }

        return null;
    }
    #endregion
}
