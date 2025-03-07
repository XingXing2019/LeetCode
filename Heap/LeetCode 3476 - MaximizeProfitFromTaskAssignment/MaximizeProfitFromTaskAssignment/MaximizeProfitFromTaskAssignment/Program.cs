long MaxProfit(int[] workers, int[][] tasks)
{
    var dict = new Dictionary<int, PriorityQueue<long, long>>();
    foreach (var t in tasks)
    {
        if (!dict.ContainsKey(t[0]))
            dict[t[0]] = new PriorityQueue<long, long>();
        dict[t[0]].Enqueue(t[1], -t[1]);
    }
    var res = 0L;
    foreach (var w in workers)
    {
        if (!dict.ContainsKey(w) || dict[w].Count == 0) continue;
        res += dict[w].Dequeue();
    }
    var addition = 0L;
    foreach (var t in dict.Keys)
    {
        if (dict[t].Count == 0) continue;
        addition = Math.Max(addition, dict[t].Peek());
    }
    return res + addition;
}