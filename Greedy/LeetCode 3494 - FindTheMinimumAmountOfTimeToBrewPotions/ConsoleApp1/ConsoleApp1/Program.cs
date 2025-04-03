int[] parents;
int[] rank;

int NumberOfComponents(int[][] properties, int k)
{
    parents = new int[properties.Length];
    for (int i = 0; i < parents.Length; i++)
        parents[i] = i;
    rank = new int[properties.Length];
    var res = properties.Length;
    for (int i = 0; i < properties.Length; i++)
    {
        for (int j = i; j < properties.Length; j++)
        {
            if (Intersect(new HashSet<int>(properties[i]), new HashSet<int>(properties[j]), k) && Union(i, j))
                res--;
        }
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
    if (rootX == rootY)
        return false;
    if (rank[rootX] >= rank[rootY])
    {
        parents[rootY] = rootX;
        if (rank[rootX] == rank[rootY])
            rank[rootX]++;
    }
    else
        parents[rootX] = rootY;
    return true;
}

bool Intersect(HashSet<int> a, HashSet<int> b, int k)
{
    return a.Count(b.Contains) >= k;
}