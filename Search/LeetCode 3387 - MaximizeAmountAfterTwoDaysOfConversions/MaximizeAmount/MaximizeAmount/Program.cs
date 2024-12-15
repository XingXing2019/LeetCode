var initialCurrency = "USD";
var pairs1 = new List<IList<string>>
{
    new List<string> { "USD","EUR" },
};
double[] rates1 = { 1 };
var pairs2 = new List<IList<string>>
{
    new List<string> { "EUR","JPY" },
};
double[] rates2 = { 10 };
Console.WriteLine(MaxAmount(initialCurrency, pairs1, rates1, pairs2, rates2));

double MaxAmount(string initialCurrency, IList<IList<string>> pairs1, double[] rates1, IList<IList<string>> pairs2, double[] rates2)
{
    var res = 1d;
    var graph1 = BuildGraph(pairs1, rates1);
    var graph2 = BuildGraph(pairs2, rates2);
    var cost1 = BFS(graph1, initialCurrency, true);
    var cost2 = BFS(graph2, initialCurrency, false);
    foreach (var currency in cost1.Keys)
    {
        if (!cost2.ContainsKey(currency)) continue;
        res = Math.Max(res, cost1[currency] * (1 / cost2[currency]));
    }
    return res;
}

Dictionary<string, Dictionary<string, double>> BuildGraph(IList<IList<string>> pairs, double[] rates)
{
    var res = new Dictionary<string, Dictionary<string, double>>();
    for (int i = 0; i < pairs.Count; i++)
    {
        string start = pairs[i][0], end = pairs[i][1];
        if (!res.ContainsKey(start))
            res[start] = new Dictionary<string, double>();
        res[start][end] = rates[i];
        if (!res.ContainsKey(end))
            res[end] = new Dictionary<string, double>();
        res[end][start] = 1 / rates[i];
    }
    return res;
}

Dictionary<string, double> BFS(Dictionary<string, Dictionary<string, double>> graph, string init, bool isMax)
{
    var res = new Dictionary<string, double>();
    var queue = new Queue<(string, double)>();
    var visited = new HashSet<string>();
    queue.Enqueue((init, 1));
    visited.Add(init);
    while (queue.Count != 0)
    {
        var cur = queue.Dequeue();
        if (!graph.ContainsKey(cur.Item1)) continue;
        foreach (var next in graph[cur.Item1])
        {
            if (visited.Add(next.Key))
            {
                if (isMax)
                    res[next.Key] = Math.Max(res.GetValueOrDefault(next.Key, 0), cur.Item2 * next.Value);
                else
                    res[next.Key] = Math.Min(res.GetValueOrDefault(next.Key, double.MaxValue), cur.Item2 * next.Value);
                queue.Enqueue((next.Key, cur.Item2 * next.Value));
            }
        }
    }
    return res;
}
