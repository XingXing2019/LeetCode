var n = 5;
int[][] edges = new int[][]
{
    new int[] {1, 0, 1},
    new int[] {2, 0, 2},
    new int[] {3, 0, 1},
    new int[] {4, 3, 1},
    new int[] {2, 1, 1},
};
var threshold = 2;

Console.WriteLine(MinMaxWeight(n, edges, threshold));

int MinMaxWeight(int n, int[][] edges, int threshold)
{
    var graph = new List<int[]>[n];
    for (int i = 0; i < n; i++)
        graph[i] = new List<int[]>();
    var max = 0;
    foreach (var e in edges)
    {
        graph[e[1]].Add(new int[] { e[0], e[2] });
        max = Math.Max(max, e[2]);
    }
    int li = 0, hi = max;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        var nodes = new HashSet<int>();
        DFS(graph, 0, mid, nodes);
        if (nodes.Count == n)
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li > max ? -1 : li;
}

void DFS(List<int[]>[] graph, int cur, int weight, HashSet<int> nodes)
{
    nodes.Add(cur);
    foreach (var next in graph[cur])
    {
        if (nodes.Contains(next[0]) || next[1] > weight) continue;
        DFS(graph, next[0], weight, nodes);
    }
}