var s = "111";
Console.WriteLine(SumOfLargestPrimes(s));

long SumOfLargestPrimes(string s)
{
    var candidates = new HashSet<long>();
    for (int i = 0; i < s.Length; i++)
    {
        var num = 0L;
        for (int j = i; j < s.Length; j++)
        {
            num = num * 10 + (s[j] - '0');
            if (num != 1 && IsPrime(num)) candidates.Add(num);
        }
    }
    var sorted = candidates.OrderByDescending(x => x).ToList();
    var res = 0L;
    for (int i = 0; i < Math.Min(3, sorted.Count); i++)
        res += sorted[i];
    return res;
}

bool IsPrime(long num)
{
    for (int i = 2; i <= Math.Sqrt(num); i++)
        if (num % i == 0) return false;
    return true;
}