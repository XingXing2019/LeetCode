int n = 3;
int[][] edges = 
{
    new[] { 0, 1, 2 },
    new[] { 1, 2, 1 },
    new[] { 0, 2, 4 },
};
int[] disappear = { 1, 3, 5 };
Console.WriteLine(MinimumTime(n, edges, disappear));

int[] MinimumTime(int n, int[][] edges, int[] disappear)
{
    var graph = new List<int[]>[n];
    var dp = new int[n];
    var res = new int[n];
    for (int i = 0; i < n; i++)
    {
        graph[i] = new List<int[]>();
        dp[i] = int.MaxValue;
    }
    dp[0] = 0;
    foreach (var edge in edges)
    {
        graph[edge[0]].Add(new[] { edge[1], edge[2] });
        graph[edge[1]].Add(new[] { edge[0], edge[2] });
    }
    var queue = new Queue<int[]>();
    queue.Enqueue(new[] { 0, 0 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int curNode = cur[0], curCost = cur[1];
        if (curCost > dp[curNode]) continue;
        foreach (var next in graph[curNode])
        {
            int nextNode = next[0], nextCost = next[1];
            if (dp[nextNode] > curCost + nextCost && disappear[nextNode] > curCost + nextCost)
            {
                dp[nextNode] = curCost + nextCost;
                queue.Enqueue(new[] { nextNode, curCost + nextCost });
            }
        }
    }
    for (int i = 0; i < n; i++)
        res[i] = dp[i] == int.MaxValue ? -1 : dp[i];
    return res;
}