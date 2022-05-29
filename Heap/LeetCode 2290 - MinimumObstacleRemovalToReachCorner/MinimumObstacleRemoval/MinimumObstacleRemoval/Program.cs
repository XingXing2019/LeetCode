// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int MinimumObstacles(int[][] grid)
{
    int m = grid.Length, n = grid[0].Length;
    var dp = new int[m][];
    for (int i = 0; i < m; i++)
    {
        dp[i] = new int[n];
        Array.Fill(dp[i], int.MaxValue);
    }
    int[] dirs = { 1, 0, -1, 0, 1 };
    var queue = new PriorityQueue<int[], int>();
    queue.Enqueue(new[] { 0, 0, 0 }, 0);
    dp[0][0] = 0;
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        if (cur[0] == m - 1 && cur[1] == n - 1)
            return cur[2];
        for (int i = 0; i < 4; i++)
        {
            int newX = cur[0] + dirs[i], newY = cur[1] + dirs[i + 1];
            if (newX < 0 || newX >= m || newY < 0 || newY >= n) continue;
            if (cur[2] + grid[newX][newY] >= dp[newX][newY]) continue;
            dp[newX][newY] = cur[2] + grid[newX][newY];
            queue.Enqueue(new[] { newX, newY, cur[2] + grid[newX][newY] }, cur[2] + grid[newX][newY]);
        }
    }
    return -1;
}