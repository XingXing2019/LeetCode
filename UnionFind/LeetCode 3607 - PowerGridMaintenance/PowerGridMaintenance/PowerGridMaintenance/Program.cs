int c = 3;
var connections = new int[][]
{
    
};
var queries = new int[][]
{
    new[] { 1, 1 },
    new[] { 2, 1 },
    new[] { 1, 1 },
};
Console.WriteLine(ProcessQueries(c, connections, queries));

int[] parents;
int[] rank;

int[] ProcessQueries(int c, int[][] connections, int[][] queries)
{
    parents = new int[c + 1];
    for (int i = 0; i < parents.Length; i++)
        parents[i] = i;
    rank = new int[c + 1];
    foreach (var connection in connections)
        Union(connection[0], connection[1]);
    var dict = new Dictionary<int, SortedSet<int>>();
    var roots = new Dictionary<int, int>();
    for (int i = 1; i < parents.Length; i++)
    {
        var root = Find(parents[i]);
        roots[i] = root;
        if (!dict.ContainsKey(root))
            dict[root] = new SortedSet<int>();
        dict[root].Add(i);
    }
    var res = new List<int>();
    foreach (var query in queries)
    {
        int x = query[1], root = roots[x];
        if (query[0] == 1)
        {
            var stations = dict[root];
            var station = stations.Contains(x) ? x : stations.Count == 0 ? -1 : stations.Min;
            res.Add(station);
        }
        else
            dict[root].Remove(x);
    }
    return res.ToArray();
}

int Find(int x)
{
    if (parents[x] != x)
        parents[x] = Find(parents[x]);
    return parents[x];
}

void Union(int x, int y)
{
    int rootX = Find(x), rootY = Find(y);
    if (rootX == rootY)
        return;
    if (rank[rootX] < rank[rootY])
        parents[rootX] = rootY;
    else
    {
        if (rank[rootX] == rank[rootY])
            rank[rootX]++;
        parents[rootY] = rootX;
    }
}