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
    int[] dir = { 1, 0, -1, 0, 1 };
    var queue = new PriorityQueue<int[], int>();
    queue.Enqueue(new[] { 0, 0, 0, 2 }, 0);
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int x = cur[0], y = cur[1], time = cur[2], last = cur[3];
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i], newY = y + dir[i + 1];
            if (newX < 0 || newX >= moveTime.Length || newY < 0 || newY >= moveTime[0].Length)
                continue;
            var move = last == 1 ? 2 : 1;
            var newTime = Math.Max(time, moveTime[newX][newY]) + move;
            if (dp[newX][newY] > newTime)
            {
                dp[newX][newY] = newTime;
                queue.Enqueue(new[] { newX, newY, newTime, move }, newTime);
            }
        }
    }
    return dp[^1][^1];
}