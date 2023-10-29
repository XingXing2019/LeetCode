var nums = new List<int> { 4, 1, 3, 2, 1, 5 };
var target = 7;
Console.WriteLine(LengthOfLongestSubsequence(nums, target));

int LengthOfLongestSubsequence(IList<int> nums, int target)
{
    var dp = new int[target + 1][];
    dp[0] = new int[nums.Count];
    for (int i = 1; i < dp.Length; i++)
    {
        dp[i] = new int[nums.Count];
        for (int j = 0; j < nums.Count; j++)
        {
            dp[i][j] = j == 0 ? -1 : dp[i][j - 1];
            if (i - nums[j] < 0) continue;
            var last = j != 0 ? dp[i - nums[j]][j - 1] : nums[j] == i ? 0 : -1;
            if (last == -1)
                dp[i][j] = Math.Max(dp[i][j], last);
            else
                dp[i][j] = Math.Max(dp[i][j], last + 1);
        }
    }
    return dp[^1][^1];
}