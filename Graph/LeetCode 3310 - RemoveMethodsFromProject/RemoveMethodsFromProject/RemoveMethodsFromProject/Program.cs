int n = 3, k = 2;
int[][] invocations = new[]
{
    new[] { 1, 2 },
    new[] { 0, 1 },
    new[] { 2, 0 },
};
Console.WriteLine(RemainingMethods(n, k, invocations));


int[] parents;
int[] rank;

IList<int> RemainingMethods(int n, int k, int[][] invocations)
{
    var res = new HashSet<int>();
    parents = new int[n];
    rank = new int[n];
    var graph = new List<int>[n];
    for (int i = 0; i < n; i++)
    {
        graph[i] = new List<int>();
        parents[i] = i;
        res.Add(i);
    }
    foreach (var i in invocations)
    {
        graph[i[0]].Add(i[1]);
        Union(i[0], i[1]);
    }
    var groups = new Dictionary<int, HashSet<int>>();
    for (int i = 0; i < n; i++)
    {
        var root = Find(parents[i]);
        if (!groups.ContainsKey(root))
            groups[root] = new HashSet<int>();
        groups[root].Add(i);
    }
    var suspicious = FindSuspicious(graph, k);
    if (groups[Find(parents[k])].Count != suspicious.Count)
        return res.ToList();
    res.RemoveWhere(x => suspicious.Contains(x));
    return res.ToList();
}

int Find(int x)
{
    if (parents[x] == x)
        return x;
    return Find(parents[x]);
}

void Union(int x, int y)
{
    int rootX = Find(x), rootY = Find(y);
    if (rootX == rootY)
        return;
    if (rank[rootX] >= rank[rootY])
    {
        parents[rootY] = rootX;
        if (rank[rootX] == rank[rootY])
            rank[rootX]++;
    }
    else
        parents[rootX] = rootY;
}

HashSet<int> FindSuspicious(List<int>[] graph, int k)
{
    var res = new HashSet<int>();
    var visited = new HashSet<int> { k };
    var queue = new Queue<int>();
    queue.Enqueue(k);
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        res.Add(cur);
        foreach (var next in graph[cur])
        {
            if (!visited.Add(next)) continue;
            queue.Enqueue(next);
        }
    }
    return res;
}