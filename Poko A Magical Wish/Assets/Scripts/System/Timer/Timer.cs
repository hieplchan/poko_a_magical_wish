using System;

public abstract class Timer {
    public Action OnTimerStart = delegate { };
    public Action OnTimerStop = delegate { };

    public bool IsRunning { get; private set; }
    public float Progress => 1 - (currTime / duration); // countdown

    protected float duration = 0f;
    protected float currTime = 0f;

    protected Timer(float duration) {
        this.duration = duration;
        IsRunning = false;
    }

    public void Start() {
        currTime = duration;
        if (!IsRunning) {
            IsRunning = true;
            OnTimerStart?.Invoke();
        }
    }

    public void Stop() {
        if (IsRunning) {
            IsRunning = false;
            OnTimerStop?.Invoke();
        }
    }

    public void Pause() {
        IsRunning = false;
    }

    public void Resume() {
        IsRunning = true;
    }

    public abstract void Tick(float deltaTime);
}
