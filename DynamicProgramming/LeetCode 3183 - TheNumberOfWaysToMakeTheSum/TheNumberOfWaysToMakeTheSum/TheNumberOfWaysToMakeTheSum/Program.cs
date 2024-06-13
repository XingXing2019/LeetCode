int NumberOfWays(int n)
{
    long mod = 1_000_000_000 + 7;
    var res = GetWays(n);
    if (n >= 4) res += GetWays(n - 4);
    if (n >= 8) res += GetWays(n - 8);
    return (int)(res % mod);
}

long GetWays(int n)
{
    long mod = 1_000_000_000 + 7;
    int[] coins = { 1, 2, 6 };
    var dp = new long[coins.Length][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new long[n + 1];
        if (i == 0) Array.Fill(dp[i], 1);
        dp[i][0] = 1;
    }
    for (int i = 1; i < dp.Length; i++)
    {
        for (int j = 1; j < dp[i].Length; j++)
        {
            dp[i][j] = (dp[i - 1][j] + (j - coins[i] >= 0 ? dp[i][j - coins[i]] : 0)) % mod;
        }
    }
    return dp[^1][^1];
}