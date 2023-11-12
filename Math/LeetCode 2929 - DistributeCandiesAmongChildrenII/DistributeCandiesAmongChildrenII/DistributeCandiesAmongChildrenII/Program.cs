long DistributeCandies(int n, int limit)
{
    long res = 0;
    for (int i = 0; i < n; i++)
        res += Math.Max(Math.Min(limit, n - i) - Math.Max(0, n - i - limit), 0);
    return res;
}