var conversions = new int[][]
{
    new [] { 0, 1, 2 },
    new [] { 1, 2, 3 }
};
Console.WriteLine(BaseUnitConversions(conversions));

int[] BaseUnitConversions(int[][] conversions)
{
    long mod = 1_000_000_000 + 7;
    var graph = new List<long[]>[conversions.Length + 1];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<long[]>();
    foreach (var conversion in conversions)
        graph[conversion[0]].Add(new long[] { conversion[1], conversion[2] });
    var longRes = new long[conversions.Length + 1];
    var queue = new Queue<long[]>();
    queue.Enqueue(new long[] { 0, 1 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        long node = cur[0], weight = cur[1];
        longRes[node] = weight;
        foreach (var next in graph[node])
        {
            queue.Enqueue(new[] { next[0], next[1] * weight % mod });
        }
    }
    var res = longRes.Select(x => (int)(x % mod)).ToArray();
    return res;
}