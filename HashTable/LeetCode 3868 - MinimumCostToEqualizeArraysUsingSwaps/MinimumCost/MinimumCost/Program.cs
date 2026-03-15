int MinCost(int[] nums1, int[] nums2)
{
    var freq1 = nums1.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var freq2 = nums2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var set = new HashSet<int>(nums1);
    set.UnionWith(nums2);
    var res = 0;
    foreach (var num in set)
    {
        var f1 = freq1.GetValueOrDefault(num, 0);
        var f2 = freq2.GetValueOrDefault(num, 0);
        if ((f1 + f2) % 2 != 0) return -1;
        res += Math.Abs(f1 - f2) / 2;
    }
    return res / 2;
}