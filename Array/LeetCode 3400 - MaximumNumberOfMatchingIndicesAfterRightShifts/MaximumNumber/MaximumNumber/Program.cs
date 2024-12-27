int MaximumMatchingIndices(int[] nums1, int[] nums2)
{
    var res = 0;
    for (int i = 0; i < nums1.Length; i++)
        res = Math.Max(res, Count(nums1, nums2, i));
    return res;
}

int Count(int[] nums1, int[] nums2, int start)
{
    var res = 0;
    for (int i = 0; i < nums1.Length; i++)
    {
        if (nums1[i] == nums2[(start + i) % nums1.Length])
            res++;
    }
    return res;
}