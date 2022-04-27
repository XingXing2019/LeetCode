var s = "dcab";
int[][] pairs = new[]
{
    new[] { 0, 3 },
    new[] { 1, 2 },
    new[] { 0, 2 },
};
Console.WriteLine(SmallestStringWithSwaps(s, pairs));

int[] parents;
int[] rank;

string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
{
    parents = new int[s.Length];
    rank = new int[s.Length];
    for (int i = 0; i < s.Length; i++)
        parents[i] = i;
    foreach (var pair in pairs)
        Union(pair[0], pair[1]);
    var dict = new Dictionary<int, PriorityQueue<int, char>>();
    var indexes = new Dictionary<int, Queue<int>>();
    for (int i = 0; i < parents.Length; i++)
    {
        Find(i);
        if (!dict.ContainsKey(parents[i]))
        {
            dict[parents[i]] = new PriorityQueue<int, char>();
            indexes[parents[i]] = new Queue<int>();
        }
        dict[parents[i]].Enqueue(i, s[i]);
        indexes[parents[i]].Enqueue(i);
    }
    var letters = new char[s.Length];
    foreach (var key in dict.Keys)
    {
        var group = dict[key];
        var index = indexes[key];
        while (group.Count != 0)
        {
            var cur = group.Dequeue();
            letters[index.Dequeue()] = s[cur];
        }
    }
    return string.Join("", letters);
}


int Find(int x)
{
    if (x != parents[x])
        parents[x] = Find(parents[x]);
    return parents[x];
}

void Union(int x, int y)
{
    int rootX = Find(x), rootY = Find(y);
    if (rootX == rootY) return;
    if (rank[rootX] >= rank[rootY])
    {
        parents[rootY] = rootX;
        if (rank[rootX] == rank[rootY])
            rank[rootX]++;
    }
    else
        parents[rootX] = rootY;
}