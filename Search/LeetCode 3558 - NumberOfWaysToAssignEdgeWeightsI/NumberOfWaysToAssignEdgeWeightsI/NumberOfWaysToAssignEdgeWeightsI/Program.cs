int[][] edges =
{
    new[] { 1, 2 }
};
Console.WriteLine(AssignEdgeWeights(edges));

int AssignEdgeWeights(int[][] edges)
{
    var graph = new List<int>[edges.Length + 2];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    foreach (var e in edges)
    {
        graph[e[0]].Add(e[1]);
        graph[e[1]].Add(e[0]);
    }
    var depth = GetDepth(graph, 1, new HashSet<int> { 1 });
    return (int)Math.Pow(2, depth - 2);
}

int GetDepth(List<int>[] graph, int cur, HashSet<int> visited)
{
    var max = 0;
    foreach (var next in graph[cur])
    {
        if (!visited.Add(next)) continue;
        max = Math.Max(max, GetDepth(graph, next, visited));
        visited.Remove(next);
    }
    return max + 1;
}

long GetPow(long n, long mod)
{
    if (n == 0) return 1;
    var pow = GetPow(n / 2, mod) % mod;
    return n % 2 == 0 ? pow * pow % mod : pow * pow * 2 % mod;
}