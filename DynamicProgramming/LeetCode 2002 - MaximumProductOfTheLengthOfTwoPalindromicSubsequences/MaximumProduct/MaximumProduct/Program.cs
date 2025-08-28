var s = "leetcodecom";
Console.WriteLine(MaxProduct(s));

int MaxProduct(string s)
{
    int res = 0, max = (1 << s.Length) - 1;
    for (int i = 1; i < max; i++)
        res = Math.Max(res, GetLen(s, i) * GetLen(s, max - i));
    return res;
}

int GetLen(string s, int subset)
{
    var str = "";
    for (int i = 0; i < s.Length; i++)
    {
        if (((subset >> i) & 1) == 0) continue;
        str = s[s.Length - 1 - i] + str;
    }
    var dp = new int[str.Length][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[str.Length];
        dp[i][i] = 1;
    }
    for (int len = 2; len <= str.Length; len++)
    {
        for (int i = 0; i + len - 1 < str.Length; i++)
        {
            var j = i + len - 1;
            if (str[i] == str[j])
                dp[i][j] = dp[i + 1][j - 1] + 2;
            else
                dp[i][j] = Math.Max(dp[i + 1][j], dp[i][j - 1]);
        }
    }
    return dp[0][^1];
}