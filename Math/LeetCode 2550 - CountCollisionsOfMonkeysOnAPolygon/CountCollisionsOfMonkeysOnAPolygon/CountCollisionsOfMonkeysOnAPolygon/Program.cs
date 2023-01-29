var n = 500000003;
Console.WriteLine(MonkeyMove(n));

int MonkeyMove(int n)
{
    long mod = 1_000_000_000 + 7;
    var pow = GetPow(2, n, mod);
    return (int)((pow - 2) % mod);
}

long GetPow(long x, long y, long mod)
{
    if (y == 0)
        return 1;
    var pow = GetPow(x, y / 2, mod) % mod;
    return y % 2 == 0 ? pow * pow : pow * pow * x;
}