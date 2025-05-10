string[] grid = { "/\\", "\\/" };
Console.WriteLine(RegionsBySlashes(grid));

int RegionsBySlashes(string[] grid)
{
    var n = grid[0].Length;
    var map = new int[n * 3][];
    for (int i = 0; i < map.Length; i++)
        map[i] = new int[n * 3];
    for (var x = 0; x < grid.Length; x++)
    {
        for (int y = 0; y < grid[x].Length; y++)
        {
            if (grid[x][y] == ' ') continue;
            BuildGrid(x, y, grid[x][y], map);
        }
    }
    var res = 0;
    for (int x = 0; x < map.Length; x++)
    {
        for (int y = 0; y < map[0].Length; y++)
        {
            if (map[x][y] == 1) continue;
            DFS(map, x, y);
            res++;
        }
    }
    return res;
}

void BuildGrid(int x, int y, char slash, int[][] map)
{
    map[x * 3][y * 3] = slash == '/' ? 0 : 1;
    map[x * 3][y * 3 + 1] = 0;
    map[x * 3][y * 3 + 2] = slash == '/' ? 1 : 0;
    map[x * 3 + 1][y * 3] = 0;
    map[x * 3 + 1][y * 3 + 1] = 1;
    map[x * 3 + 1][y * 3 + 2] = 0;
    map[x * 3 + 2][y * 3] = slash == '/' ? 1 : 0;
    map[x * 3 + 2][y * 3 + 1] = 0;
    map[x * 3 + 2][y * 3 + 2] = slash == '/' ? 0 : 1;
}

void DFS(int[][] map, int x, int y)
{
    if (x < 0 || x >= map.Length || y < 0 || y >= map[0].Length || map[x][y] == 1)
        return;
    map[x][y] = 1;
    DFS(map, x + 1, y);
    DFS(map, x - 1, y);
    DFS(map, x, y + 1);
    DFS(map, x, y - 1);
}