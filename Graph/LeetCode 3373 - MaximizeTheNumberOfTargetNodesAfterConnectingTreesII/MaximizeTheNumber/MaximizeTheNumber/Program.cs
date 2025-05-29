int[][] edges1 =
{
    new[] { 0, 1 },
    new[] { 0, 2 },
    new[] { 2, 3 },
    new[] { 2, 4 },
};

int[][] edges2 =
{
    new[] { 0, 1 },
    new[] { 0, 2 },
    new[] { 0, 3 },
    new[] { 2, 7 },
    new[] { 1, 4 },
    new[] { 4, 5 },
    new[] { 4, 6 },
};

Console.WriteLine(MaxTargetNodes(edges1, edges2));

int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
{
    var graph1 = BuildGraph(edges1);
    var nodes1 = new int[edges1.Length + 1];
    var colors1 = new int[edges1.Length + 1];
    ColorNodes(graph1, 0, 0, new HashSet<int> { 0 }, ref colors1);
    int zero = colors1.Count(x => x == 0), one = colors1.Length - zero;
    for (int i = 0; i < nodes1.Length; i++)
        nodes1[i] = colors1[i] == 0 ? zero : one;
    var graph2 = BuildGraph(edges2);
    var colors2 = new int[edges2.Length + 1];
    ColorNodes(graph2, 0, 0, new HashSet<int> { 0 }, ref colors2);
    var maxOdd = 0;
    zero = colors2.Count(x => x == 0);
    one = colors2.Length - zero;
    for (int i = 0; i < edges2.Length + 1; i++)
    {
        var odd = colors2[i] == 0 ? one : zero;
        maxOdd = Math.Max(maxOdd, odd);
    }
    var res = new int[edges1.Length + 1];
    for (int i = 0; i < res.Length; i++)
        res[i] = nodes1[i] + maxOdd;
    return res;
}

List<int>[] BuildGraph(int[][] edges)
{
    var res = new List<int>[edges.Length + 1];
    for (int i = 0; i < res.Length; i++)
        res[i] = new List<int>();
    foreach (var e in edges)
    {
        res[e[0]].Add(e[1]);
        res[e[1]].Add(e[0]);
    }
    return res;
}

void ColorNodes(List<int>[] graph, int cur, int count, HashSet<int> visited, ref int[] colors)
{
    colors[cur] = count % 2;
    foreach (var next in graph[cur])
    {
        if (!visited.Add(next)) continue;
        ColorNodes(graph, next, count + 1, visited, ref colors);
        visited.Remove(next);
    }
}