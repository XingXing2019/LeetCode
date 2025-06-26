int[] nums = { 1, 1, 11, 4, 8, 1 };
Console.WriteLine(CheckPrimeFrequency(nums));
bool CheckPrimeFrequency(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var primes = GetPrimes(nums.Length);
    return freq.Any(x => primes.Contains(x.Value));
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