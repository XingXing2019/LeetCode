int[][] edges = new[]
{
    new[] { 0, 1, 5 },
    new[] { 1, 3, 10 },
    new[] { 0, 2, 3 },
    new[] { 2, 3, 4 }
};
bool[] online = { true, true, true, true };
long k = 10;
Console.WriteLine(FindMaxPathScore(edges, online, k));

int FindMaxPathScore(int[][] edges, bool[] online, long k)
{
    if (edges.Length == 0) return -1;
    int li = 0, hi = edges.Max(x => x[2]);
    while (li <= hi)
    {
        int mid = li + (hi - li) / 2;
        if (IsValid(edges, online, k, mid))
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}

bool IsValid(int[][] edges, bool[] online, long k, int mid)
{
    var graph = new List<int[]>[online.Length];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int[]>();
    foreach (var edge in edges)
    {
        if (!online[edge[0]] || !online[edge[1]] || edge[2] < mid) continue;
        graph[edge[0]].Add(new[] { edge[1], edge[2] });
    }
    var queue = new PriorityQueue<int[], int>();
    queue.Enqueue(new[] { 0, 0, 0 }, 0);
    var dp = new int[online.Length];
    Array.Fill(dp, int.MaxValue);
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        int curNode = cur[0], curSum = cur[1], curCount = cur[2];
        foreach (var next in graph[curNode])
        {
            int nextNode = next[0], nextCost = next[1];
            if (curCount + 1 < dp[nextNode] && curSum + nextCost <= k)
            {
                dp[nextNode] = curCount + 1;
                queue.Enqueue(new []{nextNode, curSum + nextCost, curCount + 1 }, curCount + 1);
            }
        }
    }
    return dp[^1] != int.MaxValue;
}