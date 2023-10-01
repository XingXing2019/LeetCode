long MaximumTripletValue(int[] nums)
{
    var suffix = new long[nums.Length];
    var max = long.MinValue;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        suffix[i] = max;
        max = Math.Max(max, nums[i]);
    }
    long res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            res = Math.Max(res, (nums[i] - nums[j]) * suffix[j]);
        }
    }
    return res;
}