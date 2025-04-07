public class StopwatchTimer : Timer {
    public StopwatchTimer() : base(0) { }

    public float GetTime => currTime;

    public override void Tick(float deltaTime) {
        if (IsRunning) {
            currTime += deltaTime;
        }
    }

    public void Reset() {
        currTime = 0;
    }
}
