int n = 6, k = 2;
int[][] edges = new[]
{
    new[] { 0, 2, 5 },
    new[] { 0, 1, 10 },
    new[] { 1, 5, 12 },
};
Console.WriteLine(MinCost(n, edges, k));

int MinCost(int n, int[][] edges, int k)
{
    int max = edges.Max(x => x[2]),  li = 0, hi = max;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var temp = edges.Where(x => x[2] <= mid).ToArray();
        if (CanReach(n, temp, k))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li > max ? -1 : li;
}

bool CanReach(int n, int[][] edges, int k)
{
    var dp = new int[n];
    Array.Fill(dp, int.MaxValue);
    var graph = new List<int[]>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int[]>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(new[] { edge[1], edge[2] });
        graph[edge[1]].Add(new[] { edge[0], edge[2] });
    }
    var queue = new Queue<int[]>();
    queue.Enqueue(new[] { 0, 0 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        foreach (var next in graph[cur[0]])
        {
            if (cur[1] + 1 < dp[next[0]])
            {
                dp[next[0]] = cur[1] + 1;
                queue.Enqueue(new[] { next[0], cur[1] + 1 });
            }
        }
    }
    return dp[^1] <= k;
}