bool SatisfiesConditions(int[][] grid)
{
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (i != 0 && grid[i][j] != grid[i - 1][j]) return false;
            if (j != 0 && grid[i][j] == grid[i][j - 1]) return false;
        }
    }
    return true;
}