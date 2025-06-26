var n = 3;
int[][] edges = new[]
{
    new[] { 0, 1 },
    new[] { 0, 2 },
};
int[] cost = { 2, 1, 3 };
Console.WriteLine(MinIncrease(n, edges, cost));

int MinIncrease(int n, int[][] edges, int[] cost)
{
    var graph = new List<int>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    var res = 0;
    DFS(graph, cost, 0, new HashSet<int> { 0 }, ref res);
    return res;
}

long DFS(List<int>[] graph, int[] cost, int cur, HashSet<int> visited, ref int res)
{
    var sums = new List<long>();
    var max = 0L;
    foreach (var next in graph[cur])
    {
        if (!visited.Add(next)) continue;
        var sum = DFS(graph, cost, next, visited, ref res);
        sums.Add(sum);
        max = Math.Max(max, sum);
        visited.Remove(next);
    }
    res += sums.Count(x => x != max);
    return max + cost[cur];
}