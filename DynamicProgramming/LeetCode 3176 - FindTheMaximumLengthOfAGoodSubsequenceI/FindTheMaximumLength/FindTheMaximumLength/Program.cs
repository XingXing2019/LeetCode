int[] nums = { 38, 40, 38, 38 };
var k = 0;
Console.WriteLine(MaximumLength(nums, k));

int MaximumLength(int[] nums, int k)
{
    var dp = new int[nums.Length + 1][][];
    for (int i = 0; i < nums.Length; i++)
    {
        dp[i] = new int[nums.Length + 1][];
        for (int j = 0; j < dp[i].Length; j++)
        {
            dp[i][j] = new int[k + 1];
            Array.Fill(dp[i][j], -1);
        }
    }
    return DFS(nums, 0, -1, k, dp);
}

int DFS(int[] nums, int index, int prev, int remain, int[][][] dp)
{
    if (index == nums.Length) return 0;
    if (dp[index][prev + 1][remain] != -1) return dp[index][prev + 1][remain];
    int skip = DFS(nums, index + 1, prev, remain, dp);
    int include = 0;
    if (prev != -1 && nums[index] == nums[prev] || prev == -1)
        include = 1 + DFS(nums, index + 1, index, remain, dp);
    else if (remain > 0)
        include = 1 + DFS(nums, index + 1, index, remain - 1, dp);
    return dp[index][prev + 1][remain] = Math.Max(include, skip);
}