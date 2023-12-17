int[] FindMissingAndRepeatedValues(int[][] grid)
{
    var n = grid.Length;
    var nums = new int[n * n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            nums[grid[i][j]]++;
        }
    }
    var res = new int[2];
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 2)
            res[0] = i;
        else if (nums[i] == 0)
            res[1] = i;
    }
    return res;
}