long MaximumProduct(int[] nums, int m)
{
    var minArr = new long[nums.Length];
    var maxArr = new long[nums.Length];
    long min = nums[^1], max = nums[^1], res = long.MinValue;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        min = Math.Min(min, nums[i]);
        max = Math.Max(max, nums[i]);
        minArr[i] = min;
        maxArr[i] = max;
    }
    for (int i = 0; i <= nums.Length - m; i++)
        res = Math.Max(res, Math.Max(nums[i] * minArr[i + m - 1], nums[i] * maxArr[i + m - 1]));
    return res;
}