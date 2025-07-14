int n = 5, k = 2;
int[][] edges = new[]
{
    new[] { 0, 1, 4 },
    new[] { 1, 2, 3 },
    new[] { 1, 3, 2 },
    new[] { 3, 4, 6 },
};
Console.WriteLine(MinCost(n, edges, k));

int[] parents;
int[] rank;

int MinCost(int n, int[][] edges, int k)
{
    if (edges.Length == 0) return 0;
    int li = 0, hi = edges.Max(x => x[2]);
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var count = CountComponents(n, edges, mid);
        if (count > k)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return Math.Max(hi, 0);
}

int CountComponents(int n, int[][] edges, int weight)
{
    parents = new int[n];
    for (int i = 0; i < n; i++)
        parents[i] = i;
    rank = new int[n];
    var res = n;
    foreach (var edge in edges)
    {
        if (edge[2] >= weight || !Union(edge[0], edge[1])) continue;
        res--;
    }
    return res;
}

int Find(int x)
{
    if (parents[x] != x)
        parents[x] = Find(parents[x]);
    return parents[x];
}

bool Union(int x, int y)
{
    int rootX = Find(x), rootY = Find(y);
    if (rootX == rootY) return false;
    if (rank[rootX] < rank[rootY])
        parents[rootX] = rootY;
    else
    {
        if (rank[rootX] == rank[rootY])
            rank[rootX]++;
        parents[rootY] = rootX;
    }
    return true;
}
