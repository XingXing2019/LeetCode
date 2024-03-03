int[][] grid = new[]
{
    new[] { 0, 1, 0, 1, 0 },
    new[] { 2, 1, 0, 1, 2 },
    new[] { 2, 2, 2, 0, 1 },
    new[] { 2, 2, 2, 2, 2 },
    new[] { 2, 1, 2, 2, 2 },
};
Console.WriteLine(MinimumOperationsToWriteY(grid));
int MinimumOperationsToWriteY(int[][] grid)
{
    var res = int.MaxValue;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (i == j) continue;
            res = Math.Min(res, CountOperations(grid, i, j));
        }
    }
    return res;
}

int CountOperations(int[][] grid, int y, int nonY)
{
    int n = grid.Length, res = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if ((i == j || i + j == n - 1) && i <= n / 2 || (j == n / 2 && i > n / 2))
            {
                if (grid[i][j] == y) continue;
                res++;
            }
            else
            {
                if (grid[i][j] == nonY) continue;
                res++;
            }
        }
    }
    return res;
}