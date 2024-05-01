char[][] grid =
{
    new[] { 'B', 'W', 'B' },
    new[] { 'W', 'B', 'W' },
    new[] { 'B', 'W', 'B' },
};
Console.WriteLine(CanMakeSquare(grid));

bool CanMakeSquare(char[][] grid)
{
    int[] dx = { 0, 1, 0, 1 };
    int[] dy = { 0, 0, 1, 1 };
    for (int x = 0; x < 2; x++)
    {
        for (int y = 0; y < 2; y++)
        {
            int white = 0, black = 0;
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i], newY = y + dy[i];
                white += grid[newX][newY] == 'W' ? 1 : 0;
                black += grid[newX][newY] == 'B' ? 1 : 0;
            }

            if (Math.Abs(white - black) == 2 || white * black == 0)
                return true;
        }
    }
    return false;
}