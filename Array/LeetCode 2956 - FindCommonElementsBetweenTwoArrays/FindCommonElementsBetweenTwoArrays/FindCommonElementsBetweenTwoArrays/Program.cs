int[] FindIntersectionValues(int[] nums1, int[] nums2)
{
    var set1 = new HashSet<int>(nums1);
    var set2 = new HashSet<int>(nums2);
    var res = new int[2];
    res[0] = nums1.Count(x => set2.Contains(x));
    res[1] = nums2.Count(x => set1.Contains(x));
    return res;
}