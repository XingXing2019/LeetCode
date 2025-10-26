long MaxAlternatingSum(int[] nums)
{
    var res = 0L;
    nums = nums.OrderBy(x => Math.Abs(x)).ToArray();
    int li = 0, hi = nums.Length - 1;
    while (li < hi)
    {
        res += nums[hi] * nums[hi] - nums[li] * nums[li];
        hi--;
        li++;
    }
    return li == hi ? res + nums[li] * nums[li] : res;
}