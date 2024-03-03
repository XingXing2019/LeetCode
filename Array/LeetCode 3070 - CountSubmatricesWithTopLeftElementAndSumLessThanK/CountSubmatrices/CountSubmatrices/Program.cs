int[][] grid = new int[][]
{
    new[] { 7, 2, 9 },
    new[] { 1, 5, 0 },
    new[] { 2, 6, 6 },
};
var k = 20;

Console.WriteLine(CountSubmatrices(grid, k));
int CountSubmatrices(int[][] grid, int k)
{
    var res = 0;
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[0].Length; j++)
        {
            grid[i][j] += j == 0 ? 0 : grid[i][j - 1];
        }
    }
    for (int j = 0; j < grid[0].Length; j++)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i][j] += i == 0 ? 0 : grid[i - 1][j];
            if (grid[i][j] > k) continue;
            res++;
        }
    }
    return res;
}