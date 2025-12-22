long MinCost(string s, int[] cost)
{
    long total = 0, res = long.MaxValue;
    var dict = new Dictionary<int, long>();
    for (int i = 0; i < s.Length; i++)
    {
        if (!dict.ContainsKey(s[i]))
            dict[s[i]] = 0;
        dict[s[i]] += cost[i];
        total += cost[i];
    }
    foreach (var num in dict.Keys)
        res = Math.Min(res, total - dict[num]);
    return res;
}