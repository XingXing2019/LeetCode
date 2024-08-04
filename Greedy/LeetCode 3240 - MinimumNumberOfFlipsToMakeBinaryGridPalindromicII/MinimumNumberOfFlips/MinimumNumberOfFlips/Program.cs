int[][] grid = new[]
{
    new[] { 1, 1, 1, 0 }
};
Console.WriteLine(MinFlips(grid));

int MinFlips(int[][] grid)
{
    int res = 0, m = grid.Length, n = grid[0].Length;
    for (int i = 0; i < m / 2; i++)
    {
        if (m % 2 != 0 && i == m / 2) continue;
        for (int j = 0; j < n / 2; j++)
        {
            if (n % 2 != 0 && j == n / 2) continue;
            int[] cells = { grid[i][j], grid[m - 1 - i][j], grid[m - 1 - i][n - 1 - j], grid[i][n - 1 - j] };
            int zeros = cells.Count(x => x == 0), ones = cells.Count(x => x == 1);
            if (zeros == 0 || ones == 0) continue;
            res += Math.Min(4 - zeros, 4 - ones);
            grid[i][j] = grid[m - 1 - i][j] = grid[m - 1 - i][n - 1 - j] = grid[i][n - 1 - j] = 4 - zeros < 4 - ones ? 1 : 0;
        }
    }
    int originalOne = 0, count = 0;
    if (m % 2 != 0)
    {
        
        for (int j = 0; j < n / 2; j++)
        {
            if (n % 2 != 0 && j == n / 2) continue;
            int cell1 = grid[m / 2][j], cell2 = grid[m / 2][n - 1 - j];
            originalOne += cell1 + cell2;
            if (cell1 != cell2)
            {
                res++;
                count++;
                grid[m / 2][j] = grid[m / 2][n - 1 - j] = 0;
            }
        }
    }
    if (n % 2 != 0)
    {
        for (int i = 0; i < m / 2; i++)
        {
            if (m % 2 != 0 && i == m / 2) continue;
            int cell1 = grid[i][n / 2], cell2 = grid[m - 1 - i][n / 2];
            originalOne += cell1 + cell2;
            if (cell1 != cell2)
            {
                res++;
                count++;
                grid[i][n / 2] = grid[m - 1 - i][n / 2] = 0;
            }
        }
    }
    if (m % 2 != 0 && n % 2 != 0 && grid[m / 2][n / 2] == 1)
    {
        res++;
        grid[m / 2][n / 2] = 0;
    }
    var one = grid.Sum(x => x.Count(y => y == 1));
    if (one % 4 != 0)
    {
        if (originalOne % 4 == 2 && count <= 1) res += 2;
    }
    return res;
}