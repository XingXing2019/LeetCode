int[] parents = { -1, 0, 0, 1, 1, 1 };
var s = "abaabc";
Console.WriteLine(FindSubtreeSizes(parents, s));

int[] FindSubtreeSizes(int[] parent, string s)
{
    var res = new int[parent.Length];
    Array.Fill(res, 1);
    var graph = new List<int>[parent.Length];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    for (int i = 1; i < parent.Length; i++)
        graph[parent[i]].Add(i);
    var map = new int[26];
    Array.Fill(map, -1);
    DFS(0, 0, graph, s, res, map);
    return res;
}

void DFS(int cur, int parent, List<int>[] graph, string s, int[] res, int[] map)
{
    var c = s[cur] - 'a';
    var last = map[c];
    map[c] = cur;
    foreach (var next in graph[cur])
        DFS(next, cur, graph, s, res, map);
    map[c] = last;
    if (map[c] != -1)
        res[map[c]] += res[cur];
    else
        res[parent] += res[cur];
}