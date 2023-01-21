int GetCommon(int[] nums1, int[] nums2)
{
    int p1 = 0, p2 = 0;
    while (p1 < nums1.Length && p2 < nums2.Length)
    {
        if (nums1[p1] == nums2[p2])
            return nums1[p1];
        if (nums1[p1] < nums2[p2])
            p1++;
        else
            p2++;
    }
    return -1;
}