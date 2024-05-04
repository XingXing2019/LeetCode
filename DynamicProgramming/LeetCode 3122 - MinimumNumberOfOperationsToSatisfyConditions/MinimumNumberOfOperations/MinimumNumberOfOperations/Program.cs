int[][] grid = new[]
{
    new[] { 1, 1, 1 },
    new[] { 0, 0, 0 },
};
Console.WriteLine(MinimumOperations(grid));

int MinimumOperations(int[][] grid)
{
    var res = int.MaxValue;
    var freq = new int[grid[0].Length][];
    for (int j = 0; j < grid[0].Length; j++)
    {
        freq[j] = new int[10];
        for (int i = 0; i < grid.Length; i++)
        {
            freq[j][grid[i][j]]++;
        }
    }
    var dp = new int[10][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[grid[0].Length];
        dp[i][0] = grid.Length - freq[0][i];
    }
    for (int j = 1; j < dp[0].Length; j++)
    {
        for (int i = 0; i < dp.Length; i++)
        {
            var min = int.MaxValue;
            for (int k = 0; k < dp.Length; k++)
            {
                if (k == i) continue;
                min = Math.Min(min, dp[k][j - 1]);
            }
            dp[i][j] = min + grid.Length - freq[j][i];
        }
    }
    for (int i = 0; i < dp.Length; i++)
        res = Math.Min(res, dp[i][^1]);
    return res;
}