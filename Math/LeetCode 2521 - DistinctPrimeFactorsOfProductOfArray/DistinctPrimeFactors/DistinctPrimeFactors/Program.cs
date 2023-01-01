int[] nums = { 2, 14, 19, 19, 5, 13, 18, 10, 15, 20 };
Console.WriteLine(DistinctPrimeFactors(nums));

int DistinctPrimeFactors(int[] nums)
{
    var res = new HashSet<int>();
    var max = nums.Max();
    var primes = GetPrimes(max);
    foreach (var num in nums)
    {
        var copy = num;
        foreach (var prime in primes)
        {
            if (copy % prime != 0)
                continue;
            res.Add(prime);
            while (copy % prime == 0)
                copy /= prime;
        }
    }
    return res.Count;
}

List<int> GetPrimes(int n)
{
    var dp = new bool[n + 1];
    Array.Fill(dp, true);
    var primes = new List<int>();
    for (int i = 2; i < dp.Length; i++)
    {
        if (dp[i])
            primes.Add(i);
        for (int j = 2; i * j < dp.Length; j++)
        {
            dp[i * j] = false;
        }
    }
    return primes;
}