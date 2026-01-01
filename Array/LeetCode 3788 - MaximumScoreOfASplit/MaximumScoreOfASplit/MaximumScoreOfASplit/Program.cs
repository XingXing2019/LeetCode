long MaximumScore(int[] nums)
{
    var res = long.MinValue;
    var prefix = new long[nums.Length];
    var suffix = new long[nums.Length];
    var min = nums[^1];
    for (int i = 0; i < nums.Length; i++)
    {
        prefix[i] = i == 0 ? nums[i] : prefix[i - 1] + nums[i];
        min = Math.Min(min, nums[^(i + 1)]);
        suffix[^(i + 1)] = min;
    }
    for (int i = 0; i < prefix.Length - 1; i++)
    {
        var score = prefix[i] - suffix[i + 1];
        res = Math.Max(res, score);
    }
    return res;
}