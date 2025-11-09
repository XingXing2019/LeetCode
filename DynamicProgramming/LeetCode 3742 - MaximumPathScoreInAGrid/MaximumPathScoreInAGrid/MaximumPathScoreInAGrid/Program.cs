int[][] grid = new int[][]
{
    new int[] { 0 },
};
var k = 1;
Console.WriteLine(MaxPathScore(grid, k));

int MaxPathScore(int[][] grid, int k)
{
    if (grid.Length == 1 && grid[0].Length == 1) return 0;
    var dp = new int[grid.Length][][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[grid[0].Length][];
        for (int j = 0; j < dp[0].Length; j++)
        {
            dp[i][j] = new int[k + 1];
            Array.Fill(dp[i][j], -1);
        }
    }
    var res = DFS(grid, 0, 0, 0, k, dp);
    return res == int.MinValue ? -1 : res;
}

int DFS(int[][] grid, int x, int y, int cost, int k, int[][][] dp)
{
    if (x >= grid.Length || y >= grid[0].Length)
        return int.MinValue;
    var curCost = cost + (grid[x][y] == 0 ? 0 : 1);
    if (curCost > k) return int.MinValue;
    if (x == grid.Length - 1 && y == grid[0].Length - 1)
        return grid[^1][^1];
    if (dp[x][y][curCost] != -1)
        return dp[x][y][curCost];
    var right = DFS(grid, x, y + 1, curCost, k, dp);
    var down = DFS(grid, x + 1, y, curCost, k, dp);
    if (right == int.MinValue && down == int.MinValue)
        return dp[x][y][curCost] = int.MinValue;
    return dp[x][y][curCost] = Math.Max(right, down) + grid[x][y];
}