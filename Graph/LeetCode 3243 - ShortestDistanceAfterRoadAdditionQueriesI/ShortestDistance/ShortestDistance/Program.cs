var n = 5;
int[][] queries = new[]
{
    new[] { 0, 2 },
    new[] { 2, 4 },
};
Console.WriteLine(ShortestDistanceAfterQueries(n, queries));

int[] ShortestDistanceAfterQueries(int n, int[][] queries)
{
    var graph = new List<int>[n];
    for (int i = 0; i < n; i++)
    {
        graph[i] = new List<int>();
        if (i != n - 1)
            graph[i].Add(i + 1);
    }
    var res = new int[queries.Length];
    for (int i = 0; i < queries.Length; i++)
    {
        graph[queries[i][0]].Add(queries[i][1]);
        res[i] = GetDistance(graph);
    }
    return res;
}

int GetDistance(List<int>[] graph)
{
    var queue = new Queue<int[]>();
    var dp = new int[graph.Length];
    Array.Fill(dp, int.MaxValue);
    queue.Enqueue(new[] { 0, 0 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int curNode = cur[0], curCost = cur[1];
        foreach (var next in graph[curNode])
        {
            if (curCost + 1 < dp[next])
            {
                dp[next] = curCost + 1;
                queue.Enqueue(new[] { next, curCost + 1 });
            }
        }
    }
    return dp[^1];
}