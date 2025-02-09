int[][] grid = new int[][]
{
    new[] { 1, 7, 3 },
    new[] { 9, 8, 2 },
    new[] { 4, 5, 6 },
};
Console.WriteLine(SortMatrix(grid));

int[][] SortMatrix(int[][] grid)
{
    var n = grid.Length;
    for (int i = 0; i < n; i++)
    {
        int x = i, y = 0;
        var nums = new List<int>();
        for (int j = 0; x < n && y < n; j++)
        {
            nums.Add(grid[x][y]);
            x++;
            y++;
        }
        nums.Sort((a, b) => b - a);
        x = i;
        y = 0;
        var index = 0;
        for (int j = 0; x < n && y < n; j++)
        {
            grid[x][y] = nums[index++];
            x++;
            y++;
        }
    }
    for (int i = 1; i < n; i++)
    {
        int x = 0, y = i;
        var nums = new List<int>();
        for (int j = 0; x < n && y < n; j++)
        {
            nums.Add(grid[x][y]);
            x++;
            y++;
        }
        nums.Sort();
        x = 0;
        y = i;
        var index = 0;
        for (int j = 0; x < n && y < n; j++)
        {
            grid[x][y] = nums[index++];
            x++;
            y++;
        }
    }
    return grid;
}