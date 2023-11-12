var n = 4;
Console.WriteLine(StringCount(n));

int StringCount(int n)
{
    long mod = 1_000_000_000 + 7;
    var res = Pow(26, n);
    res -= Pow(25, n) * 3;
    res -= Pow(25, n - 1) * n;
    res += Pow(24, n) * 3;
    res += Pow(24, n - 1) * n * 2;
    res -= Pow(23, n);
    res -= Pow(23, n - 1) * n;
    res %= mod;
    if (res < 0) res += mod;
    return (int)res;
}

long Pow(long num, int n)
{
    long mod = 1_000_000_000 + 7;
    if (n == 0) return 1;
    var pow = Pow(num, n / 2) * Pow(num, n / 2) % mod;
    return n % 2 == 0 ? pow : pow * num % mod;
}