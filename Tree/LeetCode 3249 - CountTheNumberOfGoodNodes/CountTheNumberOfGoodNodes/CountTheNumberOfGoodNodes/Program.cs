int CountGoodNodes(int[][] edges)
{
    var n = edges.Length + 1;
    var graph = new List<int>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    var res = 0;
    DFS(graph, 0, new HashSet<int> { 0 }, ref res);
    return res;
}

int DFS(List<int>[] graph, int cur, HashSet<int> visited, ref int res)
{
    var children = new List<int>();
    foreach (var child in graph[cur])
    {
        if (!visited.Add(child)) continue;
        var node = DFS(graph, child, visited, ref res);
        children.Add(node);
    }
    if (children.Count == 0 || children.All(x => x == children[0]))
        res++;
    return children.Sum() + 1;
}