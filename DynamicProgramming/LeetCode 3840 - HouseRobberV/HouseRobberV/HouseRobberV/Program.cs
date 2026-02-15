long Rob(int[] nums, int[] colors)
{
    var dp = new long[nums.Length];
    dp[0] = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
        var pre = i == 1 ? 0 : dp[i - 2];
        dp[i] = colors[i] == colors[i - 1] ? Math.Max(pre + nums[i], dp[i - 1]) : dp[i - 1] + nums[i];
    }
    return dp[^1];
}