var n = 13;
Console.WriteLine(SumOfPrimesInRange(n));

int SumOfPrimesInRange(int n)
{
    var r = int.Parse(string.Join("", n.ToString().Reverse()));
    int min = Math.Min(n, r), max = Math.Max(n, r);
    var primes = GetPrimes(max);
    var res = 0;
    for (int i = 0; i < primes.Count; i++)
    {
        if (primes[i] < min) continue;
        res += primes[i];
    }
    return res;
}

List<int> GetPrimes(int n)
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
    var res = new List<int>();
    for (int i = 2; i < dp.Length; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
    }
    return res;
}