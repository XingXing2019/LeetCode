
int MaxRemovals(string source, string pattern, int[] targetIndices)
{
    var dp = new int[pattern.Length + 1];
    Array.Fill(dp, int.MaxValue);
    dp[0] = 0;
    var isTarget = new HashSet<int>(targetIndices);
    for (int i = 0; i < source.Length; i++)
    {
        for (int j = pattern.Length; j > 0; j--)
        {
            if (source[i] == pattern[j - 1] && dp[j - 1] != int.MaxValue)
            {
                dp[j] = Math.Min(dp[j], dp[j - 1] + (isTarget.Contains(i) ? 1 : 0));
            }
        }
    }
    return targetIndices.Length - (dp[^1] == int.MaxValue ? 0 : dp[^1]);
}
