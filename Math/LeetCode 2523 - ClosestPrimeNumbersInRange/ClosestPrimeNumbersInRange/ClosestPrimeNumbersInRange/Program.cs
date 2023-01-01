int left = 10, right = 19;
Console.WriteLine(ClosestPrimes(left, right));

int[] ClosestPrimes(int left, int right)
{
    var primes = GetPrimes(right);
    int[] res = { -1, -1 };
    var diff = int.MaxValue;
    for (int i = 1; i < primes.Count; i++)
    {
        if (primes[i - 1] < left) continue;
        if (primes[i] - primes[i - 1] < diff)
        {
            diff = primes[i] - primes[i - 1];
            res = new[] { primes[i - 1], primes[i] };
        }
    }
    return res;
}

List<int> GetPrimes(int n)
{
    var dp = new bool[n + 1];
    Array.Fill(dp, true);
    var primes = new List<int>();
    for (int i = 2; i * i <= n; i++)
    {
        for (int j = 2; i * j <= n; j++)
        {
            dp[i * j] = false;
        }
    }
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        primes.Add(i);
    }
    return primes;
}