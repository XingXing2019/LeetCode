long MaxTotal(int[] value, int[] limit)
{
    var dict = new Dictionary<int, PriorityQueue<int, int>>();
    for (int i = 0; i < value.Length; i++)
    {
        int lim = limit[i], val = value[i];
        if (!dict.ContainsKey(lim))
            dict[lim] = new PriorityQueue<int, int>();
        dict[lim].Enqueue(val, val);
        if (dict[lim].Count > lim)
            dict[lim].Dequeue();
    }
    var res = 0L;
    foreach (var queue in dict.Values)
    {
        while (queue.Count != 0)
            res += queue.Dequeue();
    }
    return res;
}