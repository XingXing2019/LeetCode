string TrafficSignal(int timer)
{
    if (timer > 90) return "Invalid";
    if (timer > 30) return "Red";
    return timer == 0 ? "Green" : timer == 30 ? "Orange" : "Invalid";
}