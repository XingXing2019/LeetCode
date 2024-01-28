int[] CountOfPairs(int n, int x, int y)
{
    var res = new int[n];
    var graph = new List<int>[n];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    for (int i = 0; i < n; i++)
    {
        if (i != 0)
            graph[i].Add(i - 1);
        if (i != n - 1)
            graph[i].Add(i + 1);
    }
    graph[x - 1].Add(y - 1);
    graph[y - 1].Add(x - 1);
    for (int i = 0; i < n; i++)
        BFS(graph, i, res);
    return res;
}

void BFS(List<int>[] graph, int start, int[] res)
{
    var queue = new Queue<int>();
    queue.Enqueue(start);
    var visited = new HashSet<int> { start };
    var level = 0;
    while (queue.Count != 0)
    {
        var count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                queue.Enqueue(next);
                res[level]++;
            }
        }
        level++;
    }
}