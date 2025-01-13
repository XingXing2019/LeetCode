IList<int> ZigzagTraversal(int[][] grid)
{
    var res = new List<int>();
	var skip = false;
	for (int i = 0; i < grid.Length; i++)
	{
		for (int j = 0; j < grid[0].Length; j++)
		{
			if (!skip)
			{
				var num = i % 2 == 0 ? grid[i][j] : grid[i][^(j + 1)];
                res.Add(num);
            }
			skip = !skip;
		}
	}
	return res;
}