class neighborSum
{
    private readonly int[][] _grid;
    private readonly Dictionary<int, int[]> dict;

    public neighborSum(int[][] grid)
    {
        _grid = grid;
        dict = new Dictionary<int, int[]>();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                dict[grid[i][j]] = new[] { i, j };
            }
        }
    }

    public int AdjacentSum(int value)
    {
        var pos = dict[value];
        int x = pos[0], y = pos[1];
        int[] dir = { 1, 0, -1, 0, 1 };
        var res = 0;
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= _grid.Length || newY < 0 || newY >= _grid[0].Length)
                continue;
            res += _grid[newX][newY];
        }
        return res;
    }

    public int DiagonalSum(int value)
    {
        var pos = dict[value];
        int x = pos[0], y = pos[1];
        int[] dir = { 1, 1, -1, -1, 1 };
        var res = 0;
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= _grid.Length || newY < 0 || newY >= _grid[0].Length)
                continue;
            res += _grid[newX][newY];
        }
        return res;
    }
}