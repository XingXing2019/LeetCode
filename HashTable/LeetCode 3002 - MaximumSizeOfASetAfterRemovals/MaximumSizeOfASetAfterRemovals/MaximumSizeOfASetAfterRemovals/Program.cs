int MaximumSetSize(int[] nums1, int[] nums2)
{
    var res = new HashSet<int>();
    AddNum(nums1, nums2, res);
    AddNum(nums2, nums1, res);
    return res.Count;
}

void AddNum(int[] nums1, int[] nums2, HashSet<int> res)
{
    var set1 = new HashSet<int>(nums1);
    var set2 = new HashSet<int>(nums2);
    var count = 0;
    foreach (var num in set1)
    {
        if (count == nums1.Length / 2)
            break;
        if (set2.Contains(num) || !res.Add(num)) continue;
        count++;
    }
    foreach (var num in set1)
    {
        if (count == nums1.Length / 2)
            break;
        if (!set2.Contains(num) || !res.Add(num)) continue;
        res.Add(num);
        count++;
    }
}