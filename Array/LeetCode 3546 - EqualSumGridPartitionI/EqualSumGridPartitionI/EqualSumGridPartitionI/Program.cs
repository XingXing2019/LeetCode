int[][] grid = new int[][]
{
    new[] { 1 },
    new[] { 2 },
};
Console.WriteLine(CanPartitionGrid(grid));

bool CanPartitionGrid(int[][] grid)
{
    int m = grid.Length, n = grid[0].Length;
    var hPrefix = new int[m][];
    for (int i = 0; i < m; i++)
        hPrefix[i] = new int[n];
    var vPrefix = new int[m][];
    for (int i = 0; i < m; i++)
        vPrefix[i] = new int[n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            hPrefix[i][j] = j == 0 ? grid[i][j] : grid[i][j] + hPrefix[i][j - 1];
        }
    }
    for (int j = 0; j < n; j++)
    {
        for (int i = 0; i < m; i++)
        {
            vPrefix[i][j] = i == 0 ? grid[i][j] : grid[i][j] + vPrefix[i - 1][j];
        }
    }
    for (int i = 0; i < m - 1; i++)
    {
        int up = 0, down = 0;
        for (int j = 0; j < n; j++)
        {
            up += vPrefix[i][j];
            down += vPrefix[^1][j] - vPrefix[i][j];
        }
        if (up == down) return true;
    }
    for (int j = 0; j < n - 1; j++)
    {
        int left = 0, right = 0;
        for (int i = 0; i < m; i++)
        {
            left += hPrefix[i][j];
            right += hPrefix[i][^1] - hPrefix[i][j];
        }
        if (left == right) return true;
    }
    return false;
}