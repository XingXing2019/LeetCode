int[] nums = { -13, 3 };
Console.WriteLine(MaximumTotalCost(nums));

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


long MaximumTotalCost_DFS(int[] nums)
{
    var dp = new long[nums.Length][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new long[nums.Length];
        Array.Fill(dp[i], long.MinValue);
    }
    return DFS(nums, 0, nums.Length - 1, dp);
}

long DFS(int[] nums, int li, int hi, long[][] dp)
{
    if (li > hi) return 0;
    if (dp[li][hi] != long.MinValue) return dp[li][hi];
    var res = 0L;
    for (int i = li; i <= hi; i++)
        res += (i - li) % 2 == 0 ? nums[i] : -nums[i];
    for (int i = li; i < hi; i++)
    {
        var left = DFS(nums, li, i, dp);
        var right = DFS(nums, i + 1, hi, dp);
        res = Math.Max(res, left + right);
    }
    return dp[li][hi] = res;
}