int m = 2, n = 2;
int[][] waitCost = new int[][]
{
    new[] { 3, 5 },
    new[] { 2, 4 },
};
Console.WriteLine(MinCost(m, n, waitCost));

long MinCost(int m, int n, int[][] waitCost)
{
    var dp = new long[m + 1][][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new long[n][];
        for (int j = 0; j < dp[i].Length; j++)
        {
            dp[i][j] = new long[2];
        }
    }
    return DFS(0, 0, 1, m, n, waitCost, dp);
}

long DFS(int x, int y, int time, int m, int n, int[][] waitCost, long[][][] dp)
{
    if (x >= m || y >= n) return long.MaxValue;
    if (x == m - 1 && y == n - 1) return m * n;
    if (dp[x][y][time % 2] != 0) return dp[x][y][time % 2];
    long min = (x + 1) * (y + 1);
    if (time % 2 != 0)
    {
        min += Math.Min(DFS(x + 1, y, time + 1, m, n, waitCost, dp), DFS(x, y + 1, time + 1, m, n, waitCost, dp));
    }
    else
    {
        min += waitCost[x][y];
        min += Math.Min(DFS(x + 1, y, time + 2, m, n, waitCost, dp), DFS(x, y + 1, time + 2, m, n, waitCost, dp));
    }
    return dp[x][y][time % 2] = min;
}