long MinSum(int[] nums1, int[] nums2)
{
    long sum1 = 0, sum2 = 0;
    int count1 = 0, count2 = 0;
    foreach (var num in nums1)
    {
        if (num == 0)
            count1++;
        sum1 += num;
    }
    foreach (var num in nums2)
    {
        if (num == 0)
            count2++;
        sum2 += num;
    }
}