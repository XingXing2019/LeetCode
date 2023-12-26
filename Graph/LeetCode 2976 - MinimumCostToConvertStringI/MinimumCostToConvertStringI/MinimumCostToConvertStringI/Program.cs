string source = "aaaa", target = "bbbb";
char[] original = { 'a', 'c' };
char[] changed = { 'c', 'b' };
int[] cost = { 1, 2 };

Console.WriteLine(MinimumCost(source, target, original, changed, cost));

long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
{
    var graph = new List<int[]>[26];
    for (int i = 0; i < 26; i++)
        graph[i] = new List<int[]>();
    for (int i = 0; i < original.Length; i++)
        graph[original[i] - 'a'].Add(new[] { changed[i] - 'a', cost[i] });
    var dp = new long[26][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new long[26];
        Array.Fill(dp[i], long.MaxValue);
        dp[i][i] = 0;
    }
    long res = 0;
    var dict = new Dictionary<string, long>();
    for (int i = 0; i < source.Length; i++)
    {
        var temp = BFS(source[i] - 'a', target[i] - 'a', graph, dp, dict);
        if (temp == -1)
            return -1;
        res += temp;
    }
    return res;
}

long BFS(int source, int target, List<int[]>[] graph, long[][] dp, Dictionary<string, long> dict)
{
    if (dict.ContainsKey($"{source}:{target}"))
        return dict[$"{source}:{target}"];
    var queue = new Queue<int[]>();
    queue.Enqueue(new[] { source, 0 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        foreach (var next in graph[cur[0]])
        {
            if (dp[source][next[0]] <= cur[1] + next[1]) continue;
            dp[source][next[0]] = cur[1] + next[1];
            queue.Enqueue(new[] { next[0], cur[1] + next[1] });
        }
    }
    return dict[$"{source}:{target}"] = dp[source][target] == long.MaxValue ? -1 : dp[source][target];
}