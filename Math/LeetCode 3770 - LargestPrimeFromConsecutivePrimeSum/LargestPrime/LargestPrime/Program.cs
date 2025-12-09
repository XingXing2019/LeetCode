int LargestPrime(int n)
{
    var primes = GetPrimes(n);
    int res = 0, sum = 0;
    foreach (var prime in primes)
    {
        sum += prime;
        if (sum > n || !primes.Contains(sum)) continue;
        res = Math.Max(res, sum);
    }
    return res;
}

HashSet<int> GetPrimes(int n)
{
    var dp = new bool[n + 1];
    Array.Fill(dp, true);
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        for (int j = 2; i * j < dp.Length; j++)
        {
            dp[i * j] = false;
        }
    }
    var res = new HashSet<int>();
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
    }
    return res;
}