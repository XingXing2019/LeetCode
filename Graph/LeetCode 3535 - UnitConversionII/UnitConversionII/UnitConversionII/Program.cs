using System;

int[][] conversions = new[]
{
    new[] { 0, 1, 2 },
    new[] { 0, 2, 6 },
    new[] { 0, 3, 8 },
    new[] { 2, 4, 2 },
    new[] { 2, 5, 4 },
    new[] { 3, 6, 3 },
};

int[][] queries = new[]
{
    new[] { 1, 2 },
    new[] { 0, 4 },
    new[] { 6, 5 },
    new[] { 4, 6 },
    new[] { 6, 1 },
};

Console.WriteLine(QueryConversions(conversions, queries));

int[] QueryConversions(int[][] conversions, int[][] queries)
{
    long mod = 1_000_000_000 + 7;
    var graph = new List<int[]>[conversions.Length + 1];
    for (int i = 0; i < graph.Length; i++)
        graph[i] = new List<int[]>();
    foreach (var conversion in conversions)
        graph[conversion[0]].Add(new[] { conversion[1], conversion[2] });
    var dp = new long[conversions.Length + 1];
    var longRes = new long[queries.Length];
    var queue = new Queue<long[]>();
    queue.Enqueue(new long[] { 0, 1 });
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        dp[cur[0]] = cur[1];
        foreach (var next in graph[cur[0]])
        {
            queue.Enqueue(new[] { next[0], next[1] * cur[1] % mod });
        }
    }
    for (int i = 0; i < queries.Length; i++)
    {
        int from = queries[i][0], to = queries[i][1];
        longRes[i] = DivMod(dp[to], dp[from], mod);

    }
    return longRes.Select(x => (int)(x % mod)).ToArray();
}

long ModPow(long baseValue, long exponent, long mod)
{
    long result = 1;
    baseValue %= mod;

    while (exponent > 0)
    {
        if ((exponent & 1) == 1)
            result = (result * baseValue) % mod;

        baseValue = (baseValue * baseValue) % mod;
        exponent >>= 1;
    }

    return result;
}

long DivMod(long num, long div, long mod)
{
    return num * ModPow(div, mod - 2, mod) % mod;
}