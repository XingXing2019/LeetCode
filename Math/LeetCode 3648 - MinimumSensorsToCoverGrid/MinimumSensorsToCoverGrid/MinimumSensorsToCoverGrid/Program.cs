int MinSensors(int n, int m, int k)
{
    var x = (int)Math.Ceiling((double)n / (k * 2 + 1));
    var y = (int)Math.Ceiling((double)m / (k * 2 + 1));
    return x * y;
}