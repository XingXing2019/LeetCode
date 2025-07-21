int CountIslands(int[][] grid, int k)
{
    var res = 0;
    for (int x = 0; x < grid.Length; x++)
    {
        for (int y = 0; y < grid[0].Length; y++)
        {
            if (grid[x][y] == 0) continue;
            var sum = DFS(grid, x, y);
            if (sum % k != 0) continue;
            res++;
        }
    }
    return res;
}

int DFS(int[][] grid, int x, int y)
{
    if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] == 0)
        return 0;
    var res = grid[x][y];
    grid[x][y] = 0;
    res += DFS(grid, x + 1, y);
    res += DFS(grid, x - 1, y);
    res += DFS(grid, x, y + 1);
    res += DFS(grid, x, y - 1);
    return res;
}