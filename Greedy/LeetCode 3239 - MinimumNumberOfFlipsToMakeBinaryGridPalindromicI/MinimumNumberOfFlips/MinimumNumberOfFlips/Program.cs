int MinFlips(int[][] grid)
{
    int row = 0, col = 0;
    int m = grid.Length, n = grid[0].Length;
    for (int i = 0; i < m; i++)
    {
        int li = 0, hi = n - 1;
        while (li < hi)
        {
            if (grid[i][li++] == grid[i][hi--]) continue;
            row++;
        }
    }
    for (int j = 0; j < n; j++)
    {
        int li = 0, hi = m - 1;
        while (li < hi)
        {
            if (grid[li++][j] == grid[hi--][j]) continue;
            col++;
        }
    }
    return Math.Min(row, col);
}