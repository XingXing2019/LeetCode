int[][] MinAbsDiff(int[][] grid, int k)
{
    int m = grid.Length, n = grid[0].Length;
    var res = new int[m - k + 1][];
    for (int i = 0; i < res.Length; i++)
        res[i] = new int[n - k + 1];
    for (int x = 0; x < res.Length; x++)
    {
        for (int y = 0; y < res[0].Length; y++)
        {
            var nums = GetNums(grid, x, y, k);
            var min = int.MaxValue;
            for (int i = 1; i < nums.Count; i++)
                min = Math.Min(min, nums[i] - nums[i - 1]);
            res[x][y] = min == int.MaxValue ? 0 : min;
        }
    }
    return res;
}

List<int> GetNums(int[][] grid, int x, int y, int k)
{
    var res = new HashSet<int>();
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < k; j++)
        {
            int newX = x + i, newY = y + j;
            res.Add(grid[newX][newY]);
        }
    }
    return res.OrderBy(n => n).ToList();
}