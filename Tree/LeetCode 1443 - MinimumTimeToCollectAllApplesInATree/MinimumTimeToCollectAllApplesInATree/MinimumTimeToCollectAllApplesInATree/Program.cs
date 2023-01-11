var n = 7;
int[][] edges = new int[][]
{
    new[] { 0, 1 },
    new[] { 0, 2 },
    new[] { 1, 4 },
    new[] { 1, 5 },
    new[] { 2, 3 },
    new[] { 2, 6 },
};
var hasApple = new List<bool> { false, false, true, false, true, true, false };
Console.WriteLine(MinTime(n, edges, hasApple));

int MinTime(int n, int[][] edges, IList<bool> hasApple)
{
    var graph = new List<int>[n];
    var paths = new HashSet<string>();
    for (int i = 0; i < n; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    DFS(graph, 0, paths, new List<int> { 0 }, new HashSet<int> { 0 }, hasApple);
    return paths.Count * 2;
}

void DFS(List<int>[] graph, int cur, HashSet<string> paths, List<int> path, HashSet<int> visited, IList<bool> hasApple)
{
    if (hasApple[cur])
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            paths.Add($"{path[i]}-{path[i + 1]}");
        }
    }
    foreach (var next in graph[cur])
    {
        if (!visited.Add(next)) continue;
        path.Add(next);
        DFS(graph, next, paths, path, visited, hasApple);
        path.RemoveAt(path.Count - 1);
    }
}