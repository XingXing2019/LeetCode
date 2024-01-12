int MaximumSubtreeSize(int[][] edges, int[] colors)
{
    var res = 0;
    var graph = new List<int>[edges.Length + 1];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    DFS(0, graph, colors, new HashSet<int>(), ref res);
    return res;
}

(HashSet<int>, int) DFS(int cur, List<int>[] graph, int[] colors, HashSet<int> visited, ref int res)
{
    if (!visited.Add(cur))
        return (new HashSet<int>(), 0);
    var set = new HashSet<int> { colors[cur] };
    var count = 1;
    foreach (var next in graph[cur])
    {
        var temp = DFS(next, graph, colors, visited, ref res);
        set.UnionWith(temp.Item1);
        count += temp.Item2;
    }
    if (set.Count == 1)
        res = Math.Max(res, count);
    return (set, count);
}