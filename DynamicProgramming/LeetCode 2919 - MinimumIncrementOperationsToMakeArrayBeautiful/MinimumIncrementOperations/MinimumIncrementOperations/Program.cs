long MinIncrementOperations(int[] nums, int k)
{
    var dp = new long[nums.Length];
    for (int i = 0; i < 3; i++)
        dp[i] = Math.Max(0, k - nums[i]);
    for (int i = 3; i < dp.Length; i++)
        dp[i] = Math.Min(dp[i - 1], Math.Min(dp[i - 2], dp[i - 3])) + Math.Max(0, k - nums[i]);
    return Math.Min(dp[^1], Math.Min(dp[^2], dp[^3]));
}