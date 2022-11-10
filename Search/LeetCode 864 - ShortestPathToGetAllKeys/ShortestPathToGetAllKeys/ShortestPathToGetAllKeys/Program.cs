string[] grid = { "@abcdeABCDEFf" };
Console.WriteLine(ShortestPathAllKeys(grid));

int ShortestPathAllKeys(string[] grid)
{
    var queue = new Queue<int[]>();
    var allKeys = 0;
    var visited = new bool[grid.Length][][];
    for (int i = 0; i < grid.Length; i++)
    {
        visited[i] = new bool[grid[0].Length][];
        for (int j = 0; j < grid[0].Length; j++)
        {
            visited[i][j] = new bool[128];
            if (grid[i][j] == '@')
            {
                queue.Enqueue(new[] { i, j, 0, 0 });
                visited[i][j][0] = true;
            }
            else if ('a' <= grid[i][j] && grid[i][j] <= 'f')
                allKeys += 1 << (grid[i][j] - 'a');
        }
    }
    int[] dir = { 1, 0, -1, 0, 1 };
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        if (cur[2] == allKeys) return cur[3];
        for (int i = 0; i < 4; i++)
        {
            int newX = cur[0] + dir[i], newY = cur[1] + dir[i + 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] == '#' || visited[newX][newY][cur[2]])
                continue;
            if (grid[newX][newY] == '.' || grid[newX][newY] == '@')
            {
                queue.Enqueue(new[] { newX, newY, cur[2], cur[3] + 1 });
                visited[newX][newY][cur[2]] = true;
            }
            else if ('A' <= grid[newX][newY] && grid[newX][newY] <= 'F')
            {
                if (((cur[2] >> (grid[newX][newY] - 'A')) & 1) != 1) continue;
                queue.Enqueue(new[] { newX, newY, cur[2], cur[3] + 1 });
                visited[newX][newY][cur[2]] = true;
            }
            else if ('a' <= grid[newX][newY] && grid[newX][newY] <= 'f')
            {
                queue.Enqueue(new[] { newX, newY, cur[2] | (1 << (grid[newX][newY] - 'a')), cur[3] + 1 });
                visited[newX][newY][cur[2] | (1 << (grid[newX][newY] - 'a'))] = true;
            }
        }
    }
    return -1;
}