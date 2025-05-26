long MinCuttingCost(int n, int m, int k)
{
    if (n <= k && m <= k)
        return 0;
    if (n > k && m > k)
        return (n - k) * (long)k + (m - k) * (long)k;
    var max = Math.Max(n, m);
    return (max - k) * (long)k;
}