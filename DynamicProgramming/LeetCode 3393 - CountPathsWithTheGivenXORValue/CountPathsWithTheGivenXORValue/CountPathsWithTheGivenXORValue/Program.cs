int[][] grid = new []  
{
    new int[] { 2, 8 }
};
Console.WriteLine(CountPathsWithXorValue(grid, 8));

int CountPathsWithXorValue(int[][] grid, int k)
{
    var dp = new int[grid.Length][][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[grid[0].Length][];
        for (int j = 0; j < dp[i].Length; j++)
        {
            dp[i][j] = new int[17];
            Array.Fill(dp[i][j], -1);
        }
    }
    var mod = 1_000_000_000 + 7;
    return DFS(grid, 0, 0, 0, dp, mod, k);
}

int DFS(int[][] grid, int x, int y, int xOr, int[][][] dp, int mod, int k)
{
    if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length)
        return 0;
    if (dp[x][y][xOr] != -1)
        return dp[x][y][xOr];
    if (x == grid.Length - 1 && y == grid[0].Length - 1 && (xOr ^ grid[x][y]) == k)
        return 1;
    var right = DFS(grid, x, y + 1, xOr ^ grid[x][y], dp, mod, k);
    var down = DFS(grid, x + 1, y, xOr ^ grid[x][y], dp, mod, k);
    return dp[x][y][xOr] = (right + down) % mod;
}