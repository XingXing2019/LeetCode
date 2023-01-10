using static System.Net.Mime.MediaTypeNames;

var tickets = new List<IList<string>>
{
    new List<string> { "JFK", "KUL" },
    new List<string> { "JFK", "NRT" },
    new List<string> { "NRT", "JFK" },
};
Console.WriteLine(FindItinerary(tickets));


IList<string> FindItinerary(IList<IList<string>> tickets)
{
    var graph = new Dictionary<string, List<string>>();
    foreach (var ticket in tickets)
    {
        if (!graph.ContainsKey(ticket[0]))
            graph[ticket[0]] = new List<string>();
        graph[ticket[0]].Add(ticket[1]);
    }
    foreach (var from in graph.Keys)
        graph[from] = graph[from].OrderByDescending(x => x).ToList();
    var res = new List<string>();
    DFS(graph, "JFK", res);
    res.Reverse();
    return res;
}

void DFS(Dictionary<string, List<string>> graph, string cur, List<string> res)
{
    if (!graph.ContainsKey(cur))
    {
        res.Add(cur);
        return;
    }
    while (graph[cur].Count != 0)
    {
        var next = graph[cur][^1];
        graph[cur].RemoveAt(graph[cur].Count - 1);
        DFS(graph, next, res);
    }
    res.Add(cur);
}