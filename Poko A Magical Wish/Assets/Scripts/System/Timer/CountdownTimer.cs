public sealed class CountdownTimer : Timer {
    public CountdownTimer(float duration) : base(duration) { }

    public bool IsFinished => currTime <= 0;

    public void Reset() {
        currTime = duration;
    }

    public void Reset(float duration) {
        this.duration = duration;
        currTime = duration;
    }

    public override void Tick(float deltaTime) {
        if (IsRunning && currTime > 0) {
            currTime -= deltaTime;
        }

        if (currTime <= 0) {
            currTime = 0;
            Stop();
        }
    }
}
