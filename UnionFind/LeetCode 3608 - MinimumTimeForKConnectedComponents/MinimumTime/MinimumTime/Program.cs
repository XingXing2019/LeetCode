int MinTime(int n, int[][] edges, int k)
{
    int li = 0, hi = 1_000_000_000;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var count = CountConnectedComponents(n, edges, mid);
        if (count < k)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return li;
}

int[] parents;
int[] rank;
int CountConnectedComponents(int n, int[][] edges, int time)
{
    parents = new int[n];
    for (int i = 0; i < n; i++)
        parents[i] = i;
    rank = new int[n];
    var group = n;
    foreach (var edge in edges)
    {
        if (edge[2] <= time || !Union(edge[0], edge[1])) continue;
        group--;
    }
    return group;
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