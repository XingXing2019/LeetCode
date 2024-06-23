long MaximumTotalCost(int[] nums)
{
    if (nums.Length == 1) return nums[0];
    var dp = new long[nums.Length][];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = new long[2];
    dp[0][0] = nums[0];
    dp[0][1] = -nums[0];
    dp[1][0] = nums[0] + nums[1];
    dp[1][1] = nums[0] - nums[1];
    for (int i = 2; i < dp.Length; i++)
    {
        dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1]) + nums[i];
        dp[i][1] = dp[i - 1][0] - nums[i];
    }
    return Math.Max(dp[^1][0], dp[^1][1]);
}