double MinimumAverage(int[] nums)
{
    var res = double.MaxValue;
    Array.Sort(nums);
    int li = 0, hi = nums.Length - 1;
    while (li < hi)
        res = Math.Min(res, ((double)nums[li++] + nums[hi--]) / 2);
    return res;
}