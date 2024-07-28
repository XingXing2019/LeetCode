int l = 5, r = 7;
Console.WriteLine(NonSpecialCount(l, r));

int NonSpecialCount(int l, int r)
{
    var sqrtL = (int)Math.Ceiling(Math.Sqrt(l));
    var sqrtR = (int)Math.Floor(Math.Sqrt(r));
    var primes = CountPrime(sqrtL, sqrtR);
    return r - l - primes + 1;
}

int CountPrime(int l, int r)
{
    var dp = new bool[r + 1];
    Array.Fill(dp, true);
    dp[0] = dp[1] = false;
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        for (int j = 2; i * j < dp.Length; j++)
        {
            dp[i * j] = false;
        }
    }
    var res = 0;
    for (int i = l; i <= r; i++)
    {
        if (!dp[i]) continue;
        res++;
    }
    return res;
}