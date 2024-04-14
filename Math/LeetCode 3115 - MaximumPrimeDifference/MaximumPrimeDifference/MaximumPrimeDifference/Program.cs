int[] nums = { 4, 2, 9, 5, 3 };
Console.WriteLine(MaximumPrimeDifference(nums));

int MaximumPrimeDifference(int[] nums)
{
    var primes = GetPrimes(nums.Max());
    var first = Array.FindIndex(nums, 0, x => primes.Contains(x));
    var last = Array.FindLastIndex(nums, nums.Length - 1, x => primes.Contains(x));
    return last - first;
}

HashSet<int> GetPrimes(int n)
{
    var dp = new bool[n + 1];
    Array.Fill(dp, true);
    for (int i = 2; i < n + 1; i++)
    {
        if (!dp[i]) continue;
        for (int j = 2; i * j < n + 1; j++)
            dp[i * j] = false;
    }
    var res = new HashSet<int>();
    for (int i = 2; i < n + 1; i++)
    {
        if (!dp[i]) continue;
        res.Add(i);
    }
    return res;
}