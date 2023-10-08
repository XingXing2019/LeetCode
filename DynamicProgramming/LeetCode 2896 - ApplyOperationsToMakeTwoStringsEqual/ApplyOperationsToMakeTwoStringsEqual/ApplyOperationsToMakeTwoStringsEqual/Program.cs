int MinOperations(string s1, string s2, int x)
{
    var indexes = new List<int>();
    for (int i = 0; i < s1.Length; i++)
    {
        if (s1[i] == s2[i]) continue;
        indexes.Add(i);
    }
    if (indexes.Count % 2 != 0) return -1;
    var dp = new int[s1.Length + 1][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[s1.Length + 1];
        Array.Fill(dp[i], -1);
    }
    return DFS(indexes, 0, indexes.Count - 1, x, dp);
}

int DFS(List<int> indexes, int li, int hi, int x, int[][] dp)
{
    if (li > hi) return 0;
    if (dp[li][hi] != -1) return dp[li][hi];
    var cost = int.MaxValue;
    cost = Math.Min(cost, Math.Min(indexes[li + 1] - indexes[li], x) + DFS(indexes, li + 2, hi, x, dp));
    cost = Math.Min(cost, Math.Min(indexes[hi] - indexes[hi - 1], x) + DFS(indexes, li, hi - 2, x, dp));
    cost = Math.Min(cost, Math.Min(indexes[hi] - indexes[li], x) + DFS(indexes, li + 1, hi - 1, x, dp));
    return dp[li][hi] = cost;
}