int MaxSumDistinctTriplet(int[] x, int[] y)
{
    var dict = new Dictionary<int, List<int>>();
    for (int i = 0; i < x.Length; i++)
    {
        if (!dict.ContainsKey(x[i]))
            dict[x[i]] = new List<int>();
        dict[x[i]].Add(i);
    }
    if (dict.Count < 3) return -1;
    var max = new List<int>();
    foreach (var indexes in dict.Values)
    {
        var sorted = indexes.OrderByDescending(i => y[i]).ToList();
        max.Add(y[sorted[0]]);
    }
    max = max.OrderByDescending(i => i).ToList();
    return max[0] + max[1] + max[2];
}