int[] nums = { 294 };
Console.WriteLine(MinOperations(nums));

int MinOperations(int[] nums)
{
    int res = 0, max = nums.Max();
    var primes = GetPrimes(max + 100);
    var list = primes.ToList();
    for (int i = 0; i < nums.Length; i++)
    {
        if (i % 2 == 0 && !primes.Contains(nums[i]))
        {
            var index = ~list.BinarySearch(nums[i]);
            res += list[index] - nums[i];
        }
        else if (i % 2 != 0 && primes.Contains(nums[i]))
        {
            res += nums[i] == 2 ? 2 : 1;
        }
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
    if (!res.Contains(n))
    {

    }
    return res;
}