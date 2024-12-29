int MinimumOperations(int[][] grid)
{
    var res = 0;
	for (int j = 0; j < grid[0].Length; j++)
	{
		for (int i = 1; i < grid.Length; i++)
		{
			var diff = Math.Max(0, grid[i - 1][j] - grid[i][j] + 1);
			grid[i][j] += diff;
            res += diff;
		}
	}
	return res;
}