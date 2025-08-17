var n = 4;
int[][] edges = new[]
{
    new[] { 0, 1, 3 },
    new[] { 3, 1, 1 },
    new[] { 2, 3, 4 },
    new[] { 0, 2, 2 },
};
Console.WriteLine(MinCost(n, edges));

int MinCost(int n, int[][] edges)
{
    var curGraph = new List<int[]>[n];
    var nextGraph = new List<int[]>[n];
    for (int i = 0; i < n; i++)
    {
        curGraph[i] = new List<int[]>();
        nextGraph[i] = new List<int[]>();
    }
    foreach (var e in edges)
    {
        curGraph[e[1]].Add(new[] { e[0], e[2] });
        nextGraph[e[0]].Add(new[] { e[1], e[2] });
    }
    var dp = new int[n];
    Array.Fill(dp, int.MaxValue);
    var queue = new Queue<int[]>();
    queue.Enqueue(new[] { 0, 0 });
    dp[0] = 0;
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int curNode = cur[0], curCost = cur[1];
        foreach (var next in nextGraph[curNode])
        {
            int nextNode = next[0], nextCost = next[1];
            if (curCost + nextCost < dp[nextNode])
            {
                dp[nextNode] = curCost + nextCost;
                queue.Enqueue(new[] { nextNode, curCost + nextNode });
            }
        }
        foreach (var next in curGraph[curNode])
        {
            int nextNode = next[0], nextCost = next[1];
            if (curCost + nextCost < dp[nextNode])
            {
                dp[nextNode] = curCost + nextCost;
                queue.Enqueue(new[] { nextNode, curCost + nextNode });
            }
        }
    }
    return dp[^1] == int.MaxValue ? -1 : dp[^1];
}