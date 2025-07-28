long MaximumMedianSum(int[] nums)
{
    Array.Sort(nums);
    int li = 0, hi = nums.Length - 1;
    var res = 0L;
    while (li < hi)
    {
        res += nums[--hi];
        li++;
        hi--;
    }
    return res;
}