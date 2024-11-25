int[] nums = { 5, 0, 6 };
int k = 9, op1 = 2, op2 = 3;
Console.WriteLine(MinArraySum(nums, k, op1, op2));

int MinArraySum(int[] nums, int k, int op1, int op2)
{
    var dp = new int[nums.Length][][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[op1 + 1][];
        for (int j = 0; j < dp[i].Length; j++)
        {
            dp[i][j] = new int[op2 + 1];
            Array.Fill(dp[i][j], -1);
        }
    }
    return DFS(nums, 0, op1, op2, k, dp);
}

int DFS(int[] nums, int index, int op1, int op2, int k, int[][][] dp)
{
    if (index == nums.Length)
        return 0;
    if (dp[index][op1][op2] != -1)
        return dp[index][op1][op2];
    var res = nums[index] + DFS(nums, index + 1, op1, op2, k, dp);
    if (op1 > 0)
    {
        res = Math.Min(res, nums[index] - nums[index] / 2 + DFS(nums, index + 1, op1 - 1, op2, k, dp));
    }
    if (op2 > 0 && nums[index] >= k)
    {
        res = Math.Min(res, nums[index] - k + DFS(nums, index + 1, op1, op2 - 1, k, dp));
    }
    if (op1 > 0 && op2 > 0)
    {
        if (nums[index] >= k)
        {
            res = Math.Min(res, (nums[index] - k + 1) / 2 + DFS(nums, index + 1, op1 - 1, op2 - 1, k, dp));
        }
        if ((nums[index] + 1) / 2 >= k)
        {
            res = Math.Min(res, (nums[index] + 1) / 2 - k + DFS(nums, index + 1, op1 - 1, op2 - 1, k, dp));
        }
    }
    return dp[index][op1][op2] = res;
}