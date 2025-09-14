int[] arrives = { 9, 9, 7, 3, 5, 9, 7, 2, 6, 10, 9, 7, 9 };
int w = 10, m = 1;
Console.WriteLine(MinArrivalsToDiscard(arrives, w, m));

int MinArrivalsToDiscard(int[] arrivals, int w, int m)
{
    var removed = new HashSet<int>();
    var freq = new Dictionary<int, Queue<int>>();
    for (int i = 0; i < arrivals.Length; i++)
    {
        if (i >= w && !removed.Contains(i - w))
            freq[arrivals[i - w]].Dequeue();
        if (!freq.ContainsKey(arrivals[i]))
            freq[arrivals[i]] = new Queue<int>();
        if (freq[arrivals[i]].Count < m)
            freq[arrivals[i]].Enqueue(i);
        else
            removed.Add(i);
    }
    return removed.Count;
}