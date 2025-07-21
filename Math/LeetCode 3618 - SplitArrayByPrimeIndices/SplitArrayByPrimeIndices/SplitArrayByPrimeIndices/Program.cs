int[] nums = { 2, 3, 4 };
Console.WriteLine(SplitArray(nums));

long SplitArray(int[] nums)
{
    var primes = GetPrimes(nums.Length);
    long num1 = 0, num2 = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (primes.Contains(i))
            num1 += nums[i];
        else
            num2 += nums[i];
    }
    return Math.Abs(num1 - num2);
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