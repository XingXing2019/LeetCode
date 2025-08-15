int[][] grid = new[]
{
    new[] { 1, 2, 3, 4 },
    new[] { 5, 6, 7, 8 },
    new[] { 9, 10, 11, 12 },
    new[] { 13, 14, 15, 16 },
};

int x = 1, y = 0, k = 3;
Console.WriteLine(ReverseSubmatrix(grid, x, y, k));

int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
{
    for (int j = y; j < y + k; j++)
    {
        int li = x, hi = x + k - 1;
        while (li < hi)
        {
            (grid[li][j], grid[hi][j]) = (grid[hi][j], grid[li][j]);
            li++;
            hi--;
        }
    }
    return grid;
}