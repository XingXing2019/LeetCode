long NumberOfRightTriangles(int[][] grid)
{
    var rows = new int[grid.Length];
    var cols = new int[grid[0].Length];
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == 0) continue;
            rows[i]++;
            cols[j]++;
        }
    }
    var res = 0L;
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == 0) continue;
            var row = grid[i][j] == 1 ? rows[i] - 1 : rows[i];
            var col = grid[i][j] == 1 ? cols[j] - 1 : cols[j];
            res += row * col;
        }
    }
    return res;
}