int[] MinDistinctFreqPair(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var dict = freq.GroupBy(x => x.Value).ToDictionary(x => x.Key, x => x.OrderBy(y => y.Key).Select(y => y.Key).ToList());
    var res = new int[] { int.MaxValue, int.MaxValue };
    foreach (var k1 in dict.Keys)
    {
        foreach (var k2 in dict.Keys)
        {
            if (k1 == k2) continue;
            if (dict[k1].First() < res[0] || dict[k1].First() == res[0] && dict[k2].First() < res[1])
            {
                res = new int[] { dict[k1].First(), dict[k2].First() };
            }
        }
    }
    return res[0] == int.MaxValue ? new[] { -1, -1 } : res;
}