int[] parents = { -1, 0, 4, 0, 1, 2 };
var s = "abbbav";
Console.WriteLine(FindSubtreeSizes(parents, s));

int[] FindSubtreeSizes(int[] parent, string s)
{
    var res = new int[parent.Length];
    var moveTo = new List<int>[26];
    var graph = new List<int>[parent.Length];
    for (int i = 0; i < graph.Length; i++)
    {
        graph[i] = new List<int>();
        moveTo[i] = new List<int>();
    }
    for (int i = 0; i < parent.Length; i++)
    {
        if (parent[i] == -1) continue;
        graph[parent[i]].Add(i);
    }
    var children = new Dictionary<int, HashSet<int>>();
    GetChildren(0, graph, res, children);
    DFS(0, graph, s, parent, res, moveTo, new HashSet<int>(), children);
    return res;
}

HashSet<int> GetChildren(int cur, List<int>[] graph, int[] res, Dictionary<int, HashSet<int>> dict)
{
    var children = new HashSet<int> { cur };
    foreach (var next in graph[cur])
        children.UnionWith(GetChildren(next, graph, res, dict));
    dict[cur] = new HashSet<int>(children);
    res[cur] = dict[cur].Count;
    return children;
}

void DFS(int cur, List<int>[] graph, string s, int[] parent, int[] res, List<int>[] moveTo, HashSet<int> moved, Dictionary<int, HashSet<int>> children)
{ 
    moveTo[s[cur] - 'a'].Add(cur);
    foreach (var next in graph[cur])
    {
        var to = moveTo[s[next] - 'a'].Count == 0 ? -1 : moveTo[s[next] - 'a'][^1];
        if (to != -1 && to != parent[next] && moved.Add(next) && children[to].Contains(next))
        {
            res[parent[next]] -= children[next].Count;

        }
        DFS(next, graph, s, parent, res, moveTo, moved, children);
    }
    moveTo[s[cur] - 'a'].RemoveAt(moveTo[s[cur] - 'a'].Count - 1);
}