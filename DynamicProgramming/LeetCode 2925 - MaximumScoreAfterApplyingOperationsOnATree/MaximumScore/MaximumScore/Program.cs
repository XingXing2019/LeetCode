using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

var edges = new int[][]
{
    new[] { 7, 0 },
    new[] { 3, 1 },
    new[] { 6, 2 },
    new[] { 4, 3 },
    new[] { 4, 5 },
    new[] { 4, 6 },
    new[] { 4, 7 },
};
var values = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
Console.WriteLine(MaximumScoreAfterOperations(edges, values));

long MaximumScoreAfterOperations(int[][] edges, int[] values)
{
    var graph = new List<int>[edges.Length + 1];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int>();
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(edge[1]);
        graph[edge[1]].Add(edge[0]);
    }
    var sums = new long[edges.Length + 1];
    GetSum(0, graph, values, sums, new HashSet<int>());
    var dp = new long[edges.Length + 1];
    DFS(0, graph, values, dp, sums, new HashSet<int>());
    return dp[0];
}

long GetSum(int cur, List<int>[] graph, int[] values, long[] childrenSum, HashSet<int> visited)
{
    if (!visited.Add(cur))
        return 0;
    long sum = values[cur];
    foreach (var next in graph[cur])
        sum += GetSum(next, graph, values, childrenSum, visited);
    return childrenSum[cur] = sum;
}

void DFS(int cur, List<int>[] graph, int[] values, long[] dp, long[] sums, HashSet<int> visited)
{
    if (!visited.Add(cur)) return;
    foreach (var next in graph[cur])
        DFS(next, graph, values, dp, sums, visited);
    visited.Remove(cur);
    dp[cur] = graph[cur].Count == 1 && cur != 0 ? 0 : Math.Max(graph[cur].Sum(x => dp[x]) + values[cur], sums[cur] - values[cur]);
}