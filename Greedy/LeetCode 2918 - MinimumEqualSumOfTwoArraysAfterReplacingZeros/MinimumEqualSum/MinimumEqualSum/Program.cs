int[] nums1 = { 0, 16, 28, 12, 10, 15, 25, 24, 6, 0, 0 };
int[] nums2 = { 20, 15, 19, 5, 6, 29, 25, 8, 12 };
Console.WriteLine(MinSum(nums1, nums2));
long MinSum(int[] nums1, int[] nums2)
{
    var sum1 = nums1.Sum(x => (long)x);
    var sum2 = nums2.Sum(x => (long)x);
    var count1 = nums1.Count(x => x == 0);
    var count2 = nums2.Count(x => x == 0);
    if (sum1 + count1 > sum2 + count2)
        return GetSum(sum1, count1, sum2, count2);
    if (sum1 + count1 < sum2 + count2)
        return GetSum(sum2, count2, sum1, count1);
    return sum1 + count1;
}

long GetSum(long sum1, int count1, long sum2, int count2)
{
    if (count2 == 0) return -1;
    sum1 += count1;
    return sum1 - sum2 < count2 ? -1 : sum1;
}