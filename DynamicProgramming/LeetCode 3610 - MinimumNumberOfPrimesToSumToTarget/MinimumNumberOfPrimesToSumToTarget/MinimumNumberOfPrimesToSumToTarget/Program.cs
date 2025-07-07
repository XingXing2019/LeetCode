int n = 30, m = 16;
Console.WriteLine(MinNumberOfPrimes(n, m));

int MinNumberOfPrimes(int n, int m)
{
    var primes = GetPrimes(m);
    var dp = new int[n + 1];
    foreach (var prime in primes)
    {
        if (prime >= dp.Length) continue;
        dp[prime] = 1;
    }
    for (int i = 1; i < dp.Length; i++)
    {
        if (dp[i] == 1) continue;
        var min = int.MaxValue;
        foreach (var prime in primes)
        {
            if (i - prime <= 0 || dp[i - prime] == -1) continue;
            min = Math.Min(min, dp[i - prime]);
        }
        dp[i] = min == int.MaxValue ? -1 : min + 1;
    }
    return dp[^1];
}

List<int> GetPrimes(int m)
{
    var res = new List<int>();
    var dp = new bool[10000];
    Array.Fill(dp, true);
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        for (int j = 2; i * j < dp.Length; j++)
        {
            dp[i * j] = false;
        }
    }
    for (int i = 2; i < dp.Length && m != 0; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
        m--;
    }
    return res;
}