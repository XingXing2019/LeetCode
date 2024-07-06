int[] nums = { 1, 5, 8 };
Console.WriteLine(MaxScore(nums));
int MaxScore(int[] nums)
{
    var dp = new int[nums.Length];
    for (int i = 1; i < dp.Length; i++)
    {
        var max = 0;
        for (int j = 0; j < i; j++)
            max = Math.Max(max, (j - i) * nums[i] + dp[j]);
        dp[i] = max;
    }
    return dp[^1];
}