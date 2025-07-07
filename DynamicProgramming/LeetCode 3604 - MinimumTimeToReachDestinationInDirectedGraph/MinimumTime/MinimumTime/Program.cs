int n = 3;
int[][] edges = new[]
{
    new[] { 1, 0, 1, 3 },
};
Console.WriteLine(MinTime(n, edges));

int MinTime(int n, int[][] edges)
{
    var graph = new List<int[]>[n];
    var dp = new int[n];
    Array.Fill(dp, int.MaxValue);
    for (int i = 0; i < n; i++)
        graph[i] = new List<int[]>();
    foreach (var e in edges)
        graph[e[0]].Add(new[] { e[1], e[2], e[3] });
    var queue = new PriorityQueue<int[], int>();
    queue.Enqueue(new[] { 0, 0 }, 0);
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int curNode = cur[0], time = cur[1];
        if (curNode == n - 1)
            return time;
        foreach (var next in graph[cur[0]])
        {
            int nextNode = next[0], start = next[1], end = next[2];
            if (time > end) continue;
            var nextTime = Math.Max(time, start) + 1;
            if (dp[nextNode] > nextTime)
            {
                dp[nextNode] = nextTime;
                queue.Enqueue(new []{nextNode, nextTime }, nextTime);
            }
        }
    }
    return -1;
}