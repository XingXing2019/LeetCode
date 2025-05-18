int m = 5, n = 5;
Console.WriteLine(ColorTheGrid(m, n));

int ColorTheGrid(int m, int n)
{
    var candidates = new List<int>();
    var mod = 1_000_000_000 + 7;
    for (int i = 0; i < Math.Pow(3, m); i++)
    {
        var copy = i;
        var temp = new List<int>();
        var isValid = true;
        for (int j = 0; j < m; j++)
        {
            if (temp.Count != 0 && temp[^1] == copy % 3)
            {
                isValid = false;
                break;
            }
            temp.Add(copy % 3);
            copy /= 3;
        }
        if (!isValid) continue;
        candidates.Add(i);
    }
    var dp = new long[n][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new long[candidates.Count];
        if (i == 0) Array.Fill(dp[i], 1);
    }
    for (int i = 1; i < dp.Length; i++)
    {
        for (int j = 0; j < candidates.Count; j++)
        {
            var count = 0L;
            for (int k = 0; k < dp[i - 1].Length; k++)
            {
                if (IsValid(candidates[j], candidates[k], m))
                    count = (count + dp[i - 1][k]) % mod;
            }
            dp[i][j] = count;
        }   
    }
    var res = 0L;
    foreach (var c in dp[^1])
        res += c % mod;
    return (int)(res % mod);
}

bool IsValid(int a, int b, int m)
{
    for (int i = 0; i < m; i++)
    {
        if (a % 3 == b % 3) return false;
        a /= 3;
        b /= 3;
    }
    return true;
}