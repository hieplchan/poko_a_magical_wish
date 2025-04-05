using System;

public class FuncPredicate : IPredicate {
    private readonly Func<bool> _func;

    public FuncPredicate(Func<bool> func) {
        _func = func;
    }

    public bool Eval() {
        return _func.Invoke();
    }
}
