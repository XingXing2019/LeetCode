int[][] moveTime = new[]
{
    new[] { 0, 4 },
    new[] { 4, 4 },
};
Console.WriteLine(MinTimeToReach(moveTime));

int MinTimeToReach(int[][] moveTime)
{
    var dp = new int[moveTime.Length][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[moveTime[0].Length];
        Array.Fill(dp[i], int.MaxValue);
    }
    var queue = new Queue<int[]>();
    queue.Enqueue(new []{0, 0, 0});
    int[] dir = { 1, 0, -1, 0, 1 };
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int x = cur[0], y = cur[1], time = cur[2];
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= moveTime.Length || newY < 0 || newY >= moveTime[0].Length)
                continue;
            if (dp[newX][newY] > Math.Max(time, moveTime[newX][newY]) + 1)
            {
                dp[newX][newY] = Math.Max(time, moveTime[newX][newY]) + 1;
                queue.Enqueue(new []{newX, newY, Math.Max(time, moveTime[newX][newY]) + 1 });
            }
        }
    }
    return dp[^1][^1];
}