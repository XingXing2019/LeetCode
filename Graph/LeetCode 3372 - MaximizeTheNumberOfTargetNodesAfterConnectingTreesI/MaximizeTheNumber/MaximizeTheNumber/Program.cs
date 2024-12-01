int[][] edges1 = new[]
{
    new[] { 0, 1 },
    new[] { 0, 2 },
    new[] { 2, 3 },
    new[] { 2, 4 },
};

int[][] edges2 = new[]
{
    new[] { 0, 1 },
    new[] { 0, 2 },
    new[] { 0, 3 },
    new[] { 2, 7 },
    new[] { 1, 4 },
    new[] { 4, 5 },
    new[] { 4, 6 },
};
var k = 2;
Console.WriteLine(MaxTargetNodes(edges1, edges2, k));

int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
{
    var graph1 = BuildGraph(edges1);
    var graph2 = BuildGraph(edges2);
    var dis1 = new int[edges1.Length + 1];
    var dis2 = new int[edges2.Length + 1];
    for (int i = 0; i < dis1.Length; i++)
        dis1[i] = GetDistance(graph1, i, 0, k, new HashSet<int> { i });
    for (int i = 0; i < dis2.Length; i++)
        dis2[i] = GetDistance(graph2, i, 0, k - 1, new HashSet<int> { i });
    var max = dis2.Max();
    var res = new int[edges1.Length + 1];
    for (int i = 0; i < res.Length; i++)
        res[i] = dis1[i] + max;
    return res;
}

List<int>[] BuildGraph(int[][] edges)
{
    var graph = new List<int>[edges.Length + 1];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    return graph;
}

int GetDistance(List<int>[] graph, int cur, int dis, int k, HashSet<int> visited)
{
    var res = dis <= k ? 1 : 0;
    foreach (var next in graph[cur])
    {
        if (visited.Contains(next)) continue;
        visited.Add(next);
        res += GetDistance(graph, next, dis + 1, k, visited);
        visited.Remove(next);
    }
    return res;
}