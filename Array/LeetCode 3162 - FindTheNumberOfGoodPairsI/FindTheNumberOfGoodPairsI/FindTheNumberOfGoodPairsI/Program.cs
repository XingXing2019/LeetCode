int NumberOfPairs(int[] nums1, int[] nums2, int k)
{
    nums2 = nums2.Select(x => x * k).ToArray();
    var res = 0;
    foreach (var n1 in nums1)
    {
        foreach (var n2 in nums2)
        {
            if (n1 % n2 != 0) continue;
            res++;
        }
    }
    return res;
}