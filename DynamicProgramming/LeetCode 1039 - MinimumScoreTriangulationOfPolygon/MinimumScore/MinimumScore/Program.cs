int MinScoreTriangulation(int[] values)
{
    var dp = new int[values.Length][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[values.Length];
        Array.Fill(dp[i], int.MaxValue);
    }
    return DFS(values, 0, values.Length - 1, dp);
}

int DFS(int[] values, int i, int j, int[][] dp)
{
    if (dp[i][j] != int.MaxValue)
        return dp[i][j];
    if (j - i + 1 < 3)
        return 0;
    var min = int.MaxValue;
    for (int k = i + 1; k < j; k++)
        min = Math.Min(min, DFS(values, i, k, dp) + DFS(values, k, j, dp) + values[i] * values[k] * values[j]);
    return dp[i][j] = min;
}