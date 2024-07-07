char[][] grid = new[]
{
    new[] { '.', '.', '.' },
    new[] { '.', 'X', 'X' },
    new[] { 'Y', '.', '.' },
    new[] { 'X', '.', '.' },
};
Console.WriteLine(NumberOfSubmatrices(grid));

int NumberOfSubmatrices(char[][] grid)
{
    var res = 0;
    var matrix = new int[grid.Length][];
    var seen = new bool[grid.Length][];
    for (int i = 0; i < grid.Length; i++)
    {
        matrix[i] = new int[grid[0].Length];
        seen[i] = new bool[grid[0].Length];
        for (int j = 0; j < grid[0].Length; j++)
        {
            if (grid[i][j] == 'X')
            {
                matrix[i][j] = 1;
                seen[i][j] = true;
            }
            else if (grid[i][j] == 'Y')
                matrix[i][j] = -1;
            else
                matrix[i][j] = 0;
            matrix[i][j] = j == 0 ? matrix[i][j] : matrix[i][j] + matrix[i][j - 1];
            seen[i][j] = j == 0 ? seen[i][j] : seen[i][j] || seen[i][j - 1];
            seen[i][j] = i == 0 ? seen[i][j] : seen[i][j] || seen[i - 1][j];
        }
    }
    for (int j = 0; j < matrix[0].Length; j++)
    {
        var sum = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            sum += matrix[i][j];
            if (sum == 0 && seen[i][j]) res++;
        }
    }
    return res;
}