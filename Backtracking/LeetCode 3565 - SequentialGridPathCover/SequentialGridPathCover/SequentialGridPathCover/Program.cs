int[][] grid =
{
    new[] { 0, 1 },
    new[] { 0, 2 },
};
var k = 3;
Console.WriteLine(FindPath(grid, k));

IList<IList<int>> FindPath(int[][] grid, int k)
{
    int m = grid.Length, n = grid[0].Length;
    for (int x = 0; x < grid.Length; x++)
    {
        for (int y = 0; y < grid[0].Length; y++)
        {
            var res = new List<IList<int>>();
            DFS(grid, x, y, new List<IList<int>>(), 0, ref res);
            if (res.Count != m * n) continue;
            return res;
        }
    }
    return new List<IList<int>>();
}

void DFS(int[][] grid, int x, int y, IList<IList<int>> path, int cur, ref List<IList<int>> res)
{
    int m = grid.Length, n = grid[0].Length;
    if (path.Count == m * n)
    {
        res = new List<IList<int>>(path);
        return;
    }
    if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] != 0 && grid[x][y] != cur + 1)
        return;
    var copy = grid[x][y];
    grid[x][y] = -1;
    path.Add(new List<int> { x, y });
    DFS(grid, x + 1, y, path, copy == 0 ? cur : cur + 1, ref res);
    DFS(grid, x - 1, y, path, copy == 0 ? cur : cur + 1, ref res);
    DFS(grid, x, y + 1, path, copy == 0 ? cur : cur + 1, ref res);
    DFS(grid, x, y - 1, path, copy == 0 ? cur : cur + 1, ref res);
    path.RemoveAt(path.Count - 1);
    grid[x][y] = copy;
}