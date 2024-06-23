int[][] grid = new[]
{
    new[] { 0, 1, 0 },
    new[] { 1, 0, 1 },
};
Console.WriteLine(MinimumArea(grid));

int MinimumArea(int[][] grid)
{
    int rowLi = grid.Length, rowHi = 0;
    int colLi = grid[0].Length, colHi = 0;
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == 0) continue;
            rowLi = Math.Min(rowLi, i);
            rowHi = Math.Max(rowHi, i);
            colLi = Math.Min(colLi, j);
            colHi = Math.Max(colHi, j);
        }
    }
    return (rowHi - rowLi + 1) * (colHi - colLi + 1);
}