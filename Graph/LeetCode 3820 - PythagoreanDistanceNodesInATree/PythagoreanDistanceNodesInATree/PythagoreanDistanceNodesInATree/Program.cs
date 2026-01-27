int n = 4, x = 1, y = 2, z = 3;
int[][] edges = new[]
{
    new[] { 0, 1 },
    new[] { 0, 2 },
    new[] { 0, 3 },
};
Console.WriteLine(SpecialNodes(n, edges, x, y, z));

int SpecialNodes(int n, int[][] edges, int x, int y, int z)
{
    var graph = new List<int>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int>();
    foreach (var e in edges)
    {
        graph[e[0]].Add(e[1]);
        graph[e[1]].Add(e[0]);
    }
    var distanceX = GetDistance(x, graph);
    var distanceY = GetDistance(y, graph);
    var distanceZ = GetDistance(z, graph);
    var res = 0;
    for (int i = 0; i < n; i++)
    {
        var distances = new List<int> { distanceX[i], distanceY[i], distanceZ[i] };
        distances = distances.OrderBy(x => x).ToList();
        if (distances[0] * distances[0] + distances[1] * distances[1] == distances[2] * distances[2])
            res++;
    }
    return res;
}


Dictionary<int, int> GetDistance(int node, List<int>[] graph)
{
    var res = new Dictionary<int, int>();
    var queue = new Queue<int>();
    queue.Enqueue(node);
    var visited = new HashSet<int> { node };
    var distance = 0;
    while (queue.Count != 0)
    {
        var count = queue.Count;
        for (int i = 0; i < count; i++)
        {
            var cur = queue.Dequeue();
            res[cur] = distance;
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                queue.Enqueue(next);
            }
        }
        distance++;
    }
    return res;
}