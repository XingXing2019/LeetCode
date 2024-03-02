var edges = new int[][]
{
    new[] { 0, 6, 3 },
    new[] { 6, 5, 3 },
    new[] { 0, 3, 1 },
    new[] { 3, 2, 7 },
    new[] { 3, 1, 6 },
    new[] { 3, 4, 2 },
};
var signalSpeed = 3;
Console.WriteLine(CountPairsOfConnectableServers(edges, signalSpeed));

int[] CountPairsOfConnectableServers(int[][] edges, int signalSpeed)
{
    var n = edges.Length + 1;
    var graph = new List<int[]>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int[]>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(new[] { edge[1], edge[2] });
        graph[edge[1]].Add(new[] { edge[0], edge[2] });
    }
    var res = new int[n];
    for (int i = 0; i < n; i++)
    {
       var paths = BFS(i, graph, signalSpeed);
       if (paths.Count <= 1) continue;
       res[i] = CountPairs(paths.Values.ToList());
    }
    return res;
}

Dictionary<int, int> BFS(int root, List<int[]>[] graph, int signalSpeed)
{
    var res = new Dictionary<int, int>();
    var queue = new Queue<int[]>();
    var visited = new HashSet<int> { root };
    foreach (var next in graph[root])
    {
        queue.Enqueue(new[] { next[0], next[1], next[0] });
        visited.Add(next[0]);
    }
    while (queue.Count != 0)
    {
        var count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            if (cur[1] % signalSpeed == 0)
            {
                if (!res.ContainsKey(cur[2]))
                    res[cur[2]] = 0;
                res[cur[2]]++;
            }
            foreach (var next in graph[cur[0]])
            {
                if (!visited.Add(next[0])) continue;
                queue.Enqueue(new[] { next[0], cur[1] + next[1], cur[2] });
            }
        }
    }
    return res;
}

int CountPairs(List<int> paths)
{
    var res = 0;
    for (int i = 0; i < paths.Count; i++)
    {
        for (int j = i + 1; j < paths.Count; j++)
        {
            res += paths[i] * paths[j];
        }
    }
    return res;
}