int MaxScore(IList<IList<int>> grid)
{
    var dp = new int[grid.Count][];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = new int[grid[0].Count];
    dp[0][0] = 0;
    var min = grid[0][0];
    var res = int.MinValue;
    for (int i = 1; i < grid.Count; i++)
    {
        dp[i][0] = grid[i][0] - min;
        min = Math.Min(min, grid[i][0]);
        res = Math.Max(res, dp[i][0]);
    }
    min = grid[0][0];
    for (int j = 1; j < grid[0].Count; j++)
    {
        dp[0][j] = grid[0][j] - min;
        min = Math.Min(min, grid[0][j]);
        res = Math.Max(res, dp[0][j]);
    }
    for (int i = 1; i < dp.Length; i++)
    {
        for (int j = 1; j < dp[0].Length; j++)
        {
            var top = Math.Max(grid[i][j] - grid[i - 1][j], grid[i][j] - grid[i - 1][j] + dp[i - 1][j]);
            var left = Math.Max(grid[i][j] - grid[i][j - 1], grid[i][j] - grid[i][j - 1] + dp[i][j - 1]);
            dp[i][j] = Math.Max(top, left);
            res = Math.Max(res, dp[i][j]);
        }   
    }
    return res;
}