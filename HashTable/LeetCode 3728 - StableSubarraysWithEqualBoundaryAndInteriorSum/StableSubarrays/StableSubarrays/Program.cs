int[] capacity = { -4, 4, 0, 0, -8, -4 };
Console.WriteLine(CountStableSubarrays(capacity));

long CountStableSubarrays(int[] capacity)
{
    var dict = new Dictionary<int, Dictionary<long, HashSet<int>>>();
    long res = 0, sum = 0, last = 0;
    for (var i = 0; i < capacity.Length; i++)
    {
        var c = capacity[i];
        sum += c;
        if (!dict.ContainsKey(c))
            dict[c] = new Dictionary<long, HashSet<int>>();
        else if (dict[c].ContainsKey(last - c))
        {
            var indexes = dict[c][last - c];
            res += indexes.Contains(i - 1) ? indexes.Count - 1 : indexes.Count;
        }
        if (!dict[c].ContainsKey(sum))
            dict[c][sum] = new HashSet<int>();
        dict[c][sum].Add(i);
        last = sum;
    }
    return res;
}