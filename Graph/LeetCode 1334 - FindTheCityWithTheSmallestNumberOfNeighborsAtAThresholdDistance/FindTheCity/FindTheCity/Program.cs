int FindTheCity(int n, int[][] edges, int distanceThreshold)
{
    var graph = new List<int[]>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int[]>();
    foreach (var e in edges)
    {
        graph[e[0]].Add(new[] { e[1], e[2] });
        graph[e[1]].Add(new[] { e[0], e[2] });
    }
    int count = int.MaxValue, res = -1;
    for (int i = 0; i < n; i++)
    {
        var neighbors = GetNeighbors(i, n, graph, distanceThreshold);
        if (neighbors <= count)
        {
            count = neighbors;
            res = i;
        }
    }
    return res;
}

int GetNeighbors(int city, int n, List<int[]>[] graph, int distanceThreshold)
{
    var dp = new int[n];
    Array.Fill(dp, int.MaxValue);
    dp[city] = 0;
    var queue = new Queue<int[]>();
    queue.Enqueue(new int[] { city, 0 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int curCity = cur[0], curCost = cur[1];
        foreach (var next in graph[curCity])
        {
            int nextCity = next[0], nextCost = next[1];
            if (curCost + nextCost < dp[nextCity])
            {
                dp[nextCity] = curCost + nextCost;
                queue.Enqueue(new int[] { nextCity, curCost + nextCost });
            }
        }
    }
    var res = -1;
    for (int i = 0; i < n; i++)
    {
        if (dp[i] > distanceThreshold) continue;
        res++;
    }
    return res;
}