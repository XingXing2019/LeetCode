var s = 10;
Console.WriteLine(MaxSizedArray(s));

int MaxSizedArray(long s)
{
    var n = 1000;
    var dp = new int[n][];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = new int[n];
    for (int i = 1; i < n; i++)
        dp[i][0] = i + dp[i - 1][0];
    for (int i = 1; i < n; i++)
        dp[0][i] = i + dp[0][i - 1];
    for (int i = 1; i < n; i++)
    {
        for (int j = 1; j < n; j++)
        {
            dp[i][j] = (i | j) + dp[i - 1][j] + dp[i][j - 1] - dp[i - 1][j - 1];
        }
    }
    long li = 1, hi = n;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var sum = (mid - 1) * mid / 2 * dp[mid - 1][mid - 1];
        if (sum > s)
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return (int)li;
}