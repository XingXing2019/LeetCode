int[][] grid = new int[][]
{
    new[] { 1, 1, 1 },
    new[] { 2, 2, 2 },
    new[] { 1, 1, 1 },
};
Console.WriteLine(MinCost(grid));

int MinCost(int[][] grid)
{
    int[] dirX = { 0, 0, 1, -1 };
    int[] dirY = { 1, -1, 0, 0 };
    var queue = new PriorityQueue<int[], int>();
    var dp = new int[grid.Length][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[grid[0].Length];
        Array.Fill(dp[i], int.MaxValue);
    }
    queue.Enqueue(new[] {0, 0, 0}, 0);
    dp[0][0] = 0;
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int x = cur[0], y = cur[1], cost = cur[2];
        if (x == grid.Length - 1 && y == grid[0].Length - 1)
            return cost;
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dirX[i], newY = y + dirY[i];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                continue;
            var newCost = cost + (grid[x][y] == i + 1 ? 0 : 1);
            if (dp[newX][newY] > newCost)
            {
                dp[newX][newY] = newCost;
                queue.Enqueue(new[] { newX, newY, newCost }, newCost);
            }
        }
    }
    return -1;
}