int[][] grid = new[]
{
    new[] { 123445 },
    new[] { 2 },
    new[] { 1 },
};
Console.WriteLine(ConstructProductMatrix(grid));

int[][] ConstructProductMatrix(int[][] grid)
{
    var nums = new List<int>();
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            nums.Add(grid[i][j]);
        }
    }
    long mod = 12345;
    long[] prefix = new long[nums.Count], suffix = new long[nums.Count];
    for (int i = 0; i < nums.Count; i++)
    {
        prefix[i] = i == 0 ? 1 : prefix[i - 1] * nums[i - 1] % mod;
        suffix[^(i + 1)] = i == 0 ? 1 : suffix[^i] * nums[^i] % mod;
    }
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            var index = i * grid[0].Length + j;
            grid[i][j] = (int)(prefix[index] * suffix[index] % mod);
        }   
    }
    return grid;
}