int NumOfWays(int n)
{
    var dp = new long[27];
    long mod = 1_000_000_000 + 7, sum = 0;
    for (int p = 0; p < 27; p++)
    {
        if (!IsCurrentRowValid(p)) continue;
        dp[p] = 1;
    }
    for (int i = 1; i < n; i++)
    {
        var temp = new long[27];
        for (int p = 0; p < 27; p++)
        {
            for (int q = 0; q < 27; q++)
            {
                if (!IsCurrentRowValid(p) || !IsNextRowValid(p, q)) continue;
                temp[p] = (temp[p] + dp[q]) % mod;
            }
        }
        dp = temp;
    }
    for (int p = 0; p < 27; p++)
        sum = (sum + dp[p]) % mod;
    return (int)(sum % mod);
}

bool IsCurrentRowValid(int p)
{
    var row = new List<int>();
    for (int i = 0; i < 3; i++)
    {
        row.Add(p % 3);
        p /= 3;
    }
    return row[0] != row[1] && row[1] != row[2];
}

bool IsNextRowValid(int p, int q)
{
    var next = new List<int>();
    var cur = new List<int>();
    for (int i = 0; i < 3; i++)
    {
        next.Add(p % 3);
        cur.Add(q % 3);
        p /= 3;
        q /= 3;
    }
    return next[0] != cur[0] && next[1] != cur[1] && next[2] != cur[2];
}