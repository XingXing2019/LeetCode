int[] ResultsArray(int[] nums, int k)
{
    var dp = new int[nums.Length];
    dp[0] = 1;
    for (int i = 1; i < dp.Length; i++)
        dp[i] = nums[i] == nums[i - 1] + 1 ? dp[i - 1] + 1 : 1;
    var res = new int[nums.Length - k + 1];
    for (int i = k - 1; i < dp.Length; i++)
        res[i - k + 1] = dp[i] >= k ? nums[i] : -1;
    return res;
}