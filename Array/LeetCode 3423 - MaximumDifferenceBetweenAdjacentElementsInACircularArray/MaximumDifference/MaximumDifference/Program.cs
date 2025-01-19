int MaxAdjacentDistance(int[] nums)
{
    var res = Math.Abs(nums[0] - nums[^1]);
    for (int i = 1; i < nums.Length; i++)
        res = Math.Max(res, Math.Abs(nums[i] - nums[i - 1]));
    return res;
}