int[] parents = { -1, 0, 0, 0 };
var s = "aabc";
Console.WriteLine(LongestPath(parents, s));

int LongestPath(int[] parent, string s)
{
    var res = 0;
    var graph = new List<int>[parent.Length];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    for (int i = 1; i < parent.Length; i++)
        graph[parent[i]].Add(i);
    var dict = new Dictionary<int, int[]>();
    for (int i = 0; i < parent.Length; i++)
    {
        DFS(graph, i, s, dict);
        res = Math.Max(res, dict[i][0] + dict[i][1] - 1);
    }
    return res;
}

int DFS(List<int>[] graph, int cur, string s, Dictionary<int, int[]> dict)
{
    if (dict.ContainsKey(cur))
        return dict[cur][0];
    int max = 0, secMax = 0;
    foreach (var next in graph[cur])
    {
        if (s[cur] == s[next]) continue;
        var len = DFS(graph, next, s, dict);
        if (len > max)
        {
            secMax = max;
            max = len;
        }
        else if (len > secMax)
            secMax = len;
    }
    dict[cur] = new[] { max + 1, secMax + 1 };
    return max + 1;
}