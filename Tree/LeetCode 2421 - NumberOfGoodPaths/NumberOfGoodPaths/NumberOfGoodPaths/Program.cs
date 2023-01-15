int NumberOfGoodPaths(int[] vals, int[][] edges)
{
    var graph = new List<int>[vals.Length];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    var res = 0;
    DFS(graph, 0, -1, vals, ref res);
    return res + vals.Length;
}

Dictionary<int, int> DFS(List<int>[] graph, int cur, int parent, int[] vals, ref int res)
{
    var count = new Dictionary<int, int>();
    if (!count.ContainsKey(vals[cur]))
        count[vals[cur]] = 0;
    count[vals[cur]]++;
    foreach (var next in graph[cur])
    {
        if (next == parent) continue;
        var temp = DFS(graph, next, cur, vals, ref res);
        foreach (var num in temp.Keys)
        {
            if (num < vals[cur]) continue;
            if (count.ContainsKey(num))
                res += temp[num] * count[num];
            else
                count[num] = 0;
            count[num] += temp[num];
        }
    }
    return count;
}