int CountTrapezoids(int[][] points)
{
    long res = 0, mod = 1_000_000_000 + 7;
    var dict = new Dictionary<int, long>();
    foreach (var point in points)
    {
        if (!dict.ContainsKey(point[1]))
            dict[point[1]] = 0;
        dict[point[1]]++;
    }
    foreach (var key in dict.Keys)
    {
        var count = dict[key];
        dict[key] = (count - 1) * count / 2;
    }
    var values = dict.Values.ToList();
    var suffix = new long[values.Count];
    for (int i = suffix.Length - 1; i >= 0; i--)
        suffix[i] = i == suffix.Length - 1 ? 0 : suffix[i + 1] + values[i + 1];
    for (int i = 0; i < values.Count; i++)
    {
        if (values[i] == 0) continue;
        res = (res + values[i] * suffix[i]) % mod;
    }
    return (int)(res % mod);
}